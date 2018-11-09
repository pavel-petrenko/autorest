import { DataHandle, QuickDataSource } from '@microsoft.azure/datastore';
import { Channel, Message } from '../../message';
import { PipelinePlugin } from '../common';
import { AutoRestExtension } from '../plugin-endpoint';

/* @internal */
export function GetPlugin_External(host: AutoRestExtension, pluginName: string): PipelinePlugin {
  return async (config, input, sink) => {
    const plugin = await host;
    const pluginNames = await plugin.GetPluginNames(config.CancellationToken);
    if (pluginNames.indexOf(pluginName) === -1) {
      throw new Error(`Plugin ${pluginName} not found.`);
    }
    let shouldSkip: boolean | undefined;

    const results: Array<DataHandle> = [];
    const result = await plugin.Process(
      pluginName,
      key => config.GetEntry(key as any),
      config,
      input,
      sink,
      f => results.push(f),
      (message: Message) => {

        if (message.Channel === Channel.Control) {
          if (message.Details && message.Details.skip !== undefined) {
            shouldSkip = message.Details.skip;
          }

        } else {
          return config.Message.bind(config)(message);
        }
      },

      config.CancellationToken);
    if (!result) {
      throw new Error(`Plugin ${pluginName} reported failure.`);
    }
    return new QuickDataSource(results, shouldSkip);
  };
}
