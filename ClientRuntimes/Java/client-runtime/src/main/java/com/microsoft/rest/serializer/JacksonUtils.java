/**
 *
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 *
 */

package com.microsoft.rest.serializer;

import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.SerializationFeature;
import com.fasterxml.jackson.datatype.joda.JodaModule;
import com.google.common.base.CharMatcher;
import com.google.common.base.Joiner;
import retrofit.JacksonConverterFactory;

import java.io.IOException;
import java.io.StringWriter;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;

/**
 * A serialization helper class wrapped around {@link JacksonConverterFactory} and {@link ObjectMapper}.
 */
public class JacksonUtils {
    /**
     * An instance of {@link ObjectMapper} to serialize/deserialize objects.
     */
    private static ObjectMapper mapper;

    /**
     * An instance of {@link JacksonConverterFactory} for Retrofit to use.
     */
    private static JacksonConverterFactory converterFactory;

    /**
     * Initializes an instance of JacksonUtils with default configurations
     * applied to the object mapper.
     *
     * @param mapper the object mapper to use.
     */
    protected void initializeObjectMapper(ObjectMapper mapper) {
        mapper.configure(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS, false)
                .configure(DeserializationFeature.ACCEPT_EMPTY_STRING_AS_NULL_OBJECT, true)
                .configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false)
                .setSerializationInclusion(JsonInclude.Include.NON_NULL)
                .registerModule(new JodaModule())
                .registerModule(ByteArraySerializer.getModule())
                .registerModule(DateTimeSerializer.getModule())
                .registerModule(DateTimeRfc1123Serializer.getModule());
    }

    /**
     * Gets a static instance of {@link ObjectMapper}.
     *
     * @return an instance of {@link ObjectMapper}.
     */
    public ObjectMapper getObjectMapper() {
        if (mapper == null) {
            mapper = new ObjectMapper();
            initializeObjectMapper(mapper);
        }
        return mapper;
    }

    /**
     * Gets a static instance of JacksonConverter factory.
     *
     * @return an instance of JacksonConverter factory.
     */
    public JacksonConverterFactory getConverterFactory() {
        if (converterFactory == null) {
            converterFactory = JacksonConverterFactory.create(getObjectMapper());
        }
        return converterFactory;
    }

    /**
     * Serializes an object into a JSON string using the current {@link ObjectMapper}.
     *
     * @param object the object to serialize.
     * @return the serialized string. Null if the object to serialize is null.
     */
    public static String serialize(Object object) {
        if (object == null) {
            return null;
        }
        try {
            StringWriter writer = new StringWriter();
            new JacksonUtils().getObjectMapper().writeValue(writer, object);
            return writer.toString();
        } catch (Exception e) {
            return null;
        }
    }

    /**
     * Serializes an object into a raw string using the current {@link ObjectMapper}.
     * The leading and trailing quotes will be trimmed.
     *
     * @param object the object to serialize.
     * @return the serialized string. Null if the object to serialize is null.
     */
    public static String serializeRaw(Object object) {
        if (object == null) {
            return null;
        }
        return CharMatcher.is('"').trimFrom(serialize(object));
    }

    /**
     * Serializes a list into a string with the delimiter specified with the
     * Swagger collection format joining each individual serialized items in
     * the list.
     *
     * @param list the list to serialize.
     * @param format the Swagger collection format.
     * @return the serialized string
     */
    public static String serializeList(List<?> list, CollectionFormat format) {
        if (list == null) {
            return null;
        }
        List<String> serialized = new ArrayList<String>();
        for (Object element : list) {
            String raw = serializeRaw(element);
            serialized.add(raw != null ? raw : "");
        }
        return Joiner.on(format.getDelimiter()).join(serialized);
    }

    /**
     * Deserializes a string into a {@link T} object using the current {@link ObjectMapper}.
     *
     * @param value the string value to deserialize.
     * @param <T> the type of the deserialized object.
     * @param type the type to deserialize.
     * @return the deserialized object.
     * @throws IOException exception in deserialization
     */
    @SuppressWarnings("unchecked")
    public <T> T deserialize(String value, final Type type) throws IOException {
        if (value == null || value.isEmpty()) {
            return null;
        }
        return (T) getObjectMapper().readValue(value, new TypeReference<T>() {
            @Override
            public Type getType() {
                return type;
            }
        });
    }
}
