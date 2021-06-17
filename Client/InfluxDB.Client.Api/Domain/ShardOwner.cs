/* 
 * Influx OSS API Service
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
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
    /// ShardOwner
    /// </summary>
    [DataContract]
    public partial class ShardOwner :  IEquatable<ShardOwner>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShardOwner" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ShardOwner() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShardOwner" /> class.
        /// </summary>
        /// <param name="nodeID">ID of the node that owns a shard. (required).</param>
        public ShardOwner(long? nodeID = default(long?))
        {
            // to ensure "nodeID" is required (not null)
            if (nodeID == null)
            {
                throw new InvalidDataException("nodeID is a required property for ShardOwner and cannot be null");
            }
            else
            {
                this.NodeID = nodeID;
            }
        }

        /// <summary>
        /// ID of the node that owns a shard.
        /// </summary>
        /// <value>ID of the node that owns a shard.</value>
        [DataMember(Name="nodeID", EmitDefaultValue=false)]
        public long? NodeID { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ShardOwner {\n");
            sb.Append("  NodeID: ").Append(NodeID).Append("\n");
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
            return this.Equals(input as ShardOwner);
        }

        /// <summary>
        /// Returns true if ShardOwner instances are equal
        /// </summary>
        /// <param name="input">Instance of ShardOwner to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShardOwner input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.NodeID == input.NodeID ||
                    (this.NodeID != null &&
                    this.NodeID.Equals(input.NodeID))
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
                int hashCode = 41;
                if (this.NodeID != null)
                    hashCode = hashCode * 59 + this.NodeID.GetHashCode();
                return hashCode;
            }
        }

    }

}
