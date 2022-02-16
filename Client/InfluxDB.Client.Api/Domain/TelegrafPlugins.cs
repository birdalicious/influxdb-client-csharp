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
    /// TelegrafPlugins
    /// </summary>
    [DataContract]
    public partial class TelegrafPlugins : IEquatable<TelegrafPlugins>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TelegrafPlugins" /> class.
        /// </summary>
        /// <param name="version">version.</param>
        /// <param name="os">os.</param>
        /// <param name="plugins">plugins.</param>
        public TelegrafPlugins(string version = default, string os = default, List<TelegrafPlugin> plugins = default)
        {
            Version = version;
            Os = os;
            Plugins = plugins;
        }

        /// <summary>
        /// Gets or Sets Version
        /// </summary>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public string Version { get; set; }

        /// <summary>
        /// Gets or Sets Os
        /// </summary>
        [DataMember(Name = "os", EmitDefaultValue = false)]
        public string Os { get; set; }

        /// <summary>
        /// Gets or Sets Plugins
        /// </summary>
        [DataMember(Name = "plugins", EmitDefaultValue = false)]
        public List<TelegrafPlugin> Plugins { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TelegrafPlugins {\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  Os: ").Append(Os).Append("\n");
            sb.Append("  Plugins: ").Append(Plugins).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
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
            return Equals(input as TelegrafPlugins);
        }

        /// <summary>
        /// Returns true if TelegrafPlugins instances are equal
        /// </summary>
        /// <param name="input">Instance of TelegrafPlugins to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TelegrafPlugins input)
        {
            if (input == null)
            {
                return false;
            }

            return
                (
                    Version == input.Version ||
                    Version != null && Version.Equals(input.Version)
                ) &&
                (
                    Os == input.Os ||
                    Os != null && Os.Equals(input.Os)
                ) &&
                (
                    Plugins == input.Plugins ||
                    Plugins != null &&
                    Plugins.SequenceEqual(input.Plugins)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;

                if (Version != null)
                {
                    hashCode = hashCode * 59 + Version.GetHashCode();
                }

                if (Os != null)
                {
                    hashCode = hashCode * 59 + Os.GetHashCode();
                }

                if (Plugins != null)
                {
                    hashCode = hashCode * 59 + Plugins.GetHashCode();
                }

                return hashCode;
            }
        }
    }
}