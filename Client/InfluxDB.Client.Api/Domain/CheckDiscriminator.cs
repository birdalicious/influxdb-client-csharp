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
using JsonSubTypes;
using OpenAPIDateConverter = InfluxDB.Client.Api.Client.OpenAPIDateConverter;

namespace InfluxDB.Client.Api.Domain
{
    /// <summary>
    /// CheckDiscriminator
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "type")]
    public partial class CheckDiscriminator : CheckBase, IEquatable<CheckDiscriminator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckDiscriminator" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CheckDiscriminator()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckDiscriminator" /> class.
        /// </summary>
        public CheckDiscriminator(string name = default, string orgID = default, string taskID = default,
            DashboardQuery query = default, TaskStatusType? status = default, string description = default,
            List<Label> labels = default, CheckBaseLinks links = default) : base(name, orgID, taskID, query, status,
            description, labels, links)
        {
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CheckDiscriminator {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as CheckDiscriminator);
        }

        /// <summary>
        /// Returns true if CheckDiscriminator instances are equal
        /// </summary>
        /// <param name="input">Instance of CheckDiscriminator to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CheckDiscriminator input)
        {
            if (input == null)
            {
                return false;
            }

            return base.Equals(input);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = base.GetHashCode();

                return hashCode;
            }
        }
    }
}