// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.13.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Fixtures.AcceptanceTestsBodyByte
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Models;

    /// <summary>
    /// ByteModel operations.
    /// </summary>
    public partial class ByteModel : IServiceOperations<AutoRestSwaggerBATByteService>, IByteModel
    {
        /// <summary>
        /// Initializes a new instance of the ByteModel class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        public ByteModel(AutoRestSwaggerBATByteService client)
        {
            if (client == null) 
            {
                throw new ArgumentNullException("client");
            }
            this.Client = client;
        }

        /// <summary>
        /// Gets a reference to the AutoRestSwaggerBATByteService
        /// </summary>
        public AutoRestSwaggerBATByteService Client { get; private set; }

        /// <summary>
        /// Get null byte value
        /// </summary>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<byte[]>> GetNullWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetNull", tracingParameters);
            }
            // Construct URL
            var baseUrl = this.Client.BaseUri.AbsoluteUri;
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "byte/null").ToString();
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if ((int)statusCode != 200)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error errorBody = SafeJsonConvert.DeserializeObject<Error>(responseContent, this.Client.DeserializationSettings);
                    if (errorBody != null)
                    {
                        ex.Body = errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<byte[]>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if ((int)statusCode == 200)
            {
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result.Body = SafeJsonConvert.DeserializeObject<byte[]>(responseContent, this.Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    throw new RestException("Unable to deserialize the response.", ex);
                }
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Get empty byte value ''
        /// </summary>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<byte[]>> GetEmptyWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetEmpty", tracingParameters);
            }
            // Construct URL
            var baseUrl = this.Client.BaseUri.AbsoluteUri;
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "byte/empty").ToString();
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if ((int)statusCode != 200)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error errorBody = SafeJsonConvert.DeserializeObject<Error>(responseContent, this.Client.DeserializationSettings);
                    if (errorBody != null)
                    {
                        ex.Body = errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<byte[]>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if ((int)statusCode == 200)
            {
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result.Body = SafeJsonConvert.DeserializeObject<byte[]>(responseContent, this.Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    throw new RestException("Unable to deserialize the response.", ex);
                }
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Get non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6)
        /// </summary>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<byte[]>> GetNonAsciiWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetNonAscii", tracingParameters);
            }
            // Construct URL
            var baseUrl = this.Client.BaseUri.AbsoluteUri;
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "byte/nonAscii").ToString();
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if ((int)statusCode != 200)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error errorBody = SafeJsonConvert.DeserializeObject<Error>(responseContent, this.Client.DeserializationSettings);
                    if (errorBody != null)
                    {
                        ex.Body = errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<byte[]>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if ((int)statusCode == 200)
            {
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result.Body = SafeJsonConvert.DeserializeObject<byte[]>(responseContent, this.Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    throw new RestException("Unable to deserialize the response.", ex);
                }
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Put non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6)
        /// </summary>
        /// <param name='byteBody'>
        /// Base64-encoded non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6)
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse> PutNonAsciiWithHttpMessagesAsync(byte[] byteBody, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (byteBody == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "byteBody");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("byteBody", byteBody);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "PutNonAscii", tracingParameters);
            }
            // Construct URL
            var baseUrl = this.Client.BaseUri.AbsoluteUri;
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "byte/nonAscii").ToString();
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("PUT");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Serialize Request
            string requestContent = SafeJsonConvert.SerializeObject(byteBody, this.Client.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if ((int)statusCode != 200)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error errorBody = SafeJsonConvert.DeserializeObject<Error>(responseContent, this.Client.DeserializationSettings);
                    if (errorBody != null)
                    {
                        ex.Body = errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Get invalid byte value ':::SWAGGER::::'
        /// </summary>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<byte[]>> GetInvalidWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetInvalid", tracingParameters);
            }
            // Construct URL
            var baseUrl = this.Client.BaseUri.AbsoluteUri;
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "byte/invalid").ToString();
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if ((int)statusCode != 200)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Error errorBody = SafeJsonConvert.DeserializeObject<Error>(responseContent, this.Client.DeserializationSettings);
                    if (errorBody != null)
                    {
                        ex.Body = errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<byte[]>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if ((int)statusCode == 200)
            {
                try
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result.Body = SafeJsonConvert.DeserializeObject<byte[]>(responseContent, this.Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    throw new RestException("Unable to deserialize the response.", ex);
                }
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

    }
}
