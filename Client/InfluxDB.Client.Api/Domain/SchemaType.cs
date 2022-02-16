/* 
 * InfluxDB OSS API Service
 *
 * The InfluxDB v2 API provides a programmatic interface for all interactions with InfluxDB. Access the InfluxDB API using the `/api/v2/` endpoint. 
 *
 * OpenAPI spec version: 2.0.0
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenAPIDateConverter = InfluxDB.Client.Api.Client.OpenAPIDateConverter;

namespace InfluxDB.Client.Api.Domain
{
    /// <summary>
    /// Defines SchemaType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SchemaType
    {
        /// <summary>
        /// Enum Implicit for value: implicit
        /// </summary>
        [EnumMember(Value = "implicit")] Implicit = 1,

        /// <summary>
        /// Enum Explicit for value: explicit
        /// </summary>
        [EnumMember(Value = "explicit")] Explicit = 2
    }
}