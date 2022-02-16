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
    /// MosaicViewProperties
    /// </summary>
    [DataContract]
    public partial class MosaicViewProperties : ViewProperties, IEquatable<MosaicViewProperties>
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Mosaic for value: mosaic
            /// </summary>
            [EnumMember(Value = "mosaic")] Mosaic = 1
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public TypeEnum Type { get; set; }

        /// <summary>
        /// Defines Shape
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ShapeEnum
        {
            /// <summary>
            /// Enum ChronografV2 for value: chronograf-v2
            /// </summary>
            [EnumMember(Value = "chronograf-v2")] ChronografV2 = 1
        }

        /// <summary>
        /// Gets or Sets Shape
        /// </summary>
        [DataMember(Name = "shape", EmitDefaultValue = false)]
        public ShapeEnum Shape { get; set; }

        /// <summary>
        /// Defines HoverDimension
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum HoverDimensionEnum
        {
            /// <summary>
            /// Enum Auto for value: auto
            /// </summary>
            [EnumMember(Value = "auto")] Auto = 1,

            /// <summary>
            /// Enum X for value: x
            /// </summary>
            [EnumMember(Value = "x")] X = 2,

            /// <summary>
            /// Enum Y for value: y
            /// </summary>
            [EnumMember(Value = "y")] Y = 3,

            /// <summary>
            /// Enum Xy for value: xy
            /// </summary>
            [EnumMember(Value = "xy")] Xy = 4
        }

        /// <summary>
        /// Gets or Sets HoverDimension
        /// </summary>
        [DataMember(Name = "hoverDimension", EmitDefaultValue = false)]
        public HoverDimensionEnum? HoverDimension { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MosaicViewProperties" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MosaicViewProperties()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MosaicViewProperties" /> class.
        /// </summary>
        /// <param name="timeFormat">timeFormat.</param>
        /// <param name="type">type (required) (default to TypeEnum.Mosaic).</param>
        /// <param name="queries">queries (required).</param>
        /// <param name="colors">Colors define color encoding of data into a visualization (required).</param>
        /// <param name="shape">shape (required) (default to ShapeEnum.ChronografV2).</param>
        /// <param name="note">note (required).</param>
        /// <param name="showNoteWhenEmpty">If true, will display note when empty (required).</param>
        /// <param name="xColumn">xColumn (required).</param>
        /// <param name="generateXAxisTicks">generateXAxisTicks.</param>
        /// <param name="xTotalTicks">xTotalTicks.</param>
        /// <param name="xTickStart">xTickStart.</param>
        /// <param name="xTickStep">xTickStep.</param>
        /// <param name="yLabelColumnSeparator">yLabelColumnSeparator.</param>
        /// <param name="yLabelColumns">yLabelColumns.</param>
        /// <param name="ySeriesColumns">ySeriesColumns (required).</param>
        /// <param name="fillColumns">fillColumns (required).</param>
        /// <param name="xDomain">xDomain (required).</param>
        /// <param name="yDomain">yDomain (required).</param>
        /// <param name="xAxisLabel">xAxisLabel (required).</param>
        /// <param name="yAxisLabel">yAxisLabel (required).</param>
        /// <param name="xPrefix">xPrefix (required).</param>
        /// <param name="xSuffix">xSuffix (required).</param>
        /// <param name="yPrefix">yPrefix (required).</param>
        /// <param name="ySuffix">ySuffix (required).</param>
        /// <param name="hoverDimension">hoverDimension.</param>
        /// <param name="legendColorizeRows">legendColorizeRows.</param>
        /// <param name="legendHide">legendHide.</param>
        /// <param name="legendOpacity">legendOpacity.</param>
        /// <param name="legendOrientationThreshold">legendOrientationThreshold.</param>
        public MosaicViewProperties(string timeFormat = default, TypeEnum type = TypeEnum.Mosaic,
            List<DashboardQuery> queries = default, List<string> colors = default,
            ShapeEnum shape = ShapeEnum.ChronografV2, string note = default, bool? showNoteWhenEmpty = default,
            string xColumn = default, List<string> generateXAxisTicks = default, int? xTotalTicks = default,
            float? xTickStart = default, float? xTickStep = default, string yLabelColumnSeparator = default,
            List<string> yLabelColumns = default, List<string> ySeriesColumns = default,
            List<string> fillColumns = default, List<decimal?> xDomain = default, List<decimal?> yDomain = default,
            string xAxisLabel = default, string yAxisLabel = default, string xPrefix = default,
            string xSuffix = default, string yPrefix = default, string ySuffix = default,
            HoverDimensionEnum? hoverDimension = default, bool? legendColorizeRows = default,
            bool? legendHide = default, float? legendOpacity = default,
            int? legendOrientationThreshold = default) : base()
        {
            // to ensure "type" is required (not null)
            Type = type;
            // to ensure "queries" is required (not null)
            if (queries == null)
            {
                throw new InvalidDataException(
                    "queries is a required property for MosaicViewProperties and cannot be null");
            }

            Queries = queries;
            // to ensure "colors" is required (not null)
            if (colors == null)
            {
                throw new InvalidDataException(
                    "colors is a required property for MosaicViewProperties and cannot be null");
            }

            Colors = colors;
            // to ensure "shape" is required (not null)
            Shape = shape;
            // to ensure "note" is required (not null)
            if (note == null)
            {
                throw new InvalidDataException(
                    "note is a required property for MosaicViewProperties and cannot be null");
            }

            Note = note;
            // to ensure "showNoteWhenEmpty" is required (not null)
            if (showNoteWhenEmpty == null)
            {
                throw new InvalidDataException(
                    "showNoteWhenEmpty is a required property for MosaicViewProperties and cannot be null");
            }

            ShowNoteWhenEmpty = showNoteWhenEmpty;
            // to ensure "xColumn" is required (not null)
            if (xColumn == null)
            {
                throw new InvalidDataException(
                    "xColumn is a required property for MosaicViewProperties and cannot be null");
            }

            XColumn = xColumn;
            // to ensure "ySeriesColumns" is required (not null)
            if (ySeriesColumns == null)
            {
                throw new InvalidDataException(
                    "ySeriesColumns is a required property for MosaicViewProperties and cannot be null");
            }

            YSeriesColumns = ySeriesColumns;
            // to ensure "fillColumns" is required (not null)
            if (fillColumns == null)
            {
                throw new InvalidDataException(
                    "fillColumns is a required property for MosaicViewProperties and cannot be null");
            }

            FillColumns = fillColumns;
            // to ensure "xDomain" is required (not null)
            if (xDomain == null)
            {
                throw new InvalidDataException(
                    "xDomain is a required property for MosaicViewProperties and cannot be null");
            }

            XDomain = xDomain;
            // to ensure "yDomain" is required (not null)
            if (yDomain == null)
            {
                throw new InvalidDataException(
                    "yDomain is a required property for MosaicViewProperties and cannot be null");
            }

            YDomain = yDomain;
            // to ensure "xAxisLabel" is required (not null)
            if (xAxisLabel == null)
            {
                throw new InvalidDataException(
                    "xAxisLabel is a required property for MosaicViewProperties and cannot be null");
            }

            XAxisLabel = xAxisLabel;
            // to ensure "yAxisLabel" is required (not null)
            if (yAxisLabel == null)
            {
                throw new InvalidDataException(
                    "yAxisLabel is a required property for MosaicViewProperties and cannot be null");
            }

            YAxisLabel = yAxisLabel;
            // to ensure "xPrefix" is required (not null)
            if (xPrefix == null)
            {
                throw new InvalidDataException(
                    "xPrefix is a required property for MosaicViewProperties and cannot be null");
            }

            XPrefix = xPrefix;
            // to ensure "xSuffix" is required (not null)
            if (xSuffix == null)
            {
                throw new InvalidDataException(
                    "xSuffix is a required property for MosaicViewProperties and cannot be null");
            }

            XSuffix = xSuffix;
            // to ensure "yPrefix" is required (not null)
            if (yPrefix == null)
            {
                throw new InvalidDataException(
                    "yPrefix is a required property for MosaicViewProperties and cannot be null");
            }

            YPrefix = yPrefix;
            // to ensure "ySuffix" is required (not null)
            if (ySuffix == null)
            {
                throw new InvalidDataException(
                    "ySuffix is a required property for MosaicViewProperties and cannot be null");
            }

            YSuffix = ySuffix;
            TimeFormat = timeFormat;
            GenerateXAxisTicks = generateXAxisTicks;
            XTotalTicks = xTotalTicks;
            XTickStart = xTickStart;
            XTickStep = xTickStep;
            YLabelColumnSeparator = yLabelColumnSeparator;
            YLabelColumns = yLabelColumns;
            HoverDimension = hoverDimension;
            LegendColorizeRows = legendColorizeRows;
            LegendHide = legendHide;
            LegendOpacity = legendOpacity;
            LegendOrientationThreshold = legendOrientationThreshold;
        }

        /// <summary>
        /// Gets or Sets TimeFormat
        /// </summary>
        [DataMember(Name = "timeFormat", EmitDefaultValue = false)]
        public string TimeFormat { get; set; }


        /// <summary>
        /// Gets or Sets Queries
        /// </summary>
        [DataMember(Name = "queries", EmitDefaultValue = false)]
        public List<DashboardQuery> Queries { get; set; }

        /// <summary>
        /// Colors define color encoding of data into a visualization
        /// </summary>
        /// <value>Colors define color encoding of data into a visualization</value>
        [DataMember(Name = "colors", EmitDefaultValue = false)]
        public List<string> Colors { get; set; }


        /// <summary>
        /// Gets or Sets Note
        /// </summary>
        [DataMember(Name = "note", EmitDefaultValue = false)]
        public string Note { get; set; }

        /// <summary>
        /// If true, will display note when empty
        /// </summary>
        /// <value>If true, will display note when empty</value>
        [DataMember(Name = "showNoteWhenEmpty", EmitDefaultValue = false)]
        public bool? ShowNoteWhenEmpty { get; set; }

        /// <summary>
        /// Gets or Sets XColumn
        /// </summary>
        [DataMember(Name = "xColumn", EmitDefaultValue = false)]
        public string XColumn { get; set; }

        /// <summary>
        /// Gets or Sets GenerateXAxisTicks
        /// </summary>
        [DataMember(Name = "generateXAxisTicks", EmitDefaultValue = false)]
        public List<string> GenerateXAxisTicks { get; set; }

        /// <summary>
        /// Gets or Sets XTotalTicks
        /// </summary>
        [DataMember(Name = "xTotalTicks", EmitDefaultValue = false)]
        public int? XTotalTicks { get; set; }

        /// <summary>
        /// Gets or Sets XTickStart
        /// </summary>
        [DataMember(Name = "xTickStart", EmitDefaultValue = false)]
        public float? XTickStart { get; set; }

        /// <summary>
        /// Gets or Sets XTickStep
        /// </summary>
        [DataMember(Name = "xTickStep", EmitDefaultValue = false)]
        public float? XTickStep { get; set; }

        /// <summary>
        /// Gets or Sets YLabelColumnSeparator
        /// </summary>
        [DataMember(Name = "yLabelColumnSeparator", EmitDefaultValue = false)]
        public string YLabelColumnSeparator { get; set; }

        /// <summary>
        /// Gets or Sets YLabelColumns
        /// </summary>
        [DataMember(Name = "yLabelColumns", EmitDefaultValue = false)]
        public List<string> YLabelColumns { get; set; }

        /// <summary>
        /// Gets or Sets YSeriesColumns
        /// </summary>
        [DataMember(Name = "ySeriesColumns", EmitDefaultValue = false)]
        public List<string> YSeriesColumns { get; set; }

        /// <summary>
        /// Gets or Sets FillColumns
        /// </summary>
        [DataMember(Name = "fillColumns", EmitDefaultValue = false)]
        public List<string> FillColumns { get; set; }

        /// <summary>
        /// Gets or Sets XDomain
        /// </summary>
        [DataMember(Name = "xDomain", EmitDefaultValue = false)]
        public List<decimal?> XDomain { get; set; }

        /// <summary>
        /// Gets or Sets YDomain
        /// </summary>
        [DataMember(Name = "yDomain", EmitDefaultValue = false)]
        public List<decimal?> YDomain { get; set; }

        /// <summary>
        /// Gets or Sets XAxisLabel
        /// </summary>
        [DataMember(Name = "xAxisLabel", EmitDefaultValue = false)]
        public string XAxisLabel { get; set; }

        /// <summary>
        /// Gets or Sets YAxisLabel
        /// </summary>
        [DataMember(Name = "yAxisLabel", EmitDefaultValue = false)]
        public string YAxisLabel { get; set; }

        /// <summary>
        /// Gets or Sets XPrefix
        /// </summary>
        [DataMember(Name = "xPrefix", EmitDefaultValue = false)]
        public string XPrefix { get; set; }

        /// <summary>
        /// Gets or Sets XSuffix
        /// </summary>
        [DataMember(Name = "xSuffix", EmitDefaultValue = false)]
        public string XSuffix { get; set; }

        /// <summary>
        /// Gets or Sets YPrefix
        /// </summary>
        [DataMember(Name = "yPrefix", EmitDefaultValue = false)]
        public string YPrefix { get; set; }

        /// <summary>
        /// Gets or Sets YSuffix
        /// </summary>
        [DataMember(Name = "ySuffix", EmitDefaultValue = false)]
        public string YSuffix { get; set; }


        /// <summary>
        /// Gets or Sets LegendColorizeRows
        /// </summary>
        [DataMember(Name = "legendColorizeRows", EmitDefaultValue = false)]
        public bool? LegendColorizeRows { get; set; }

        /// <summary>
        /// Gets or Sets LegendHide
        /// </summary>
        [DataMember(Name = "legendHide", EmitDefaultValue = false)]
        public bool? LegendHide { get; set; }

        /// <summary>
        /// Gets or Sets LegendOpacity
        /// </summary>
        [DataMember(Name = "legendOpacity", EmitDefaultValue = false)]
        public float? LegendOpacity { get; set; }

        /// <summary>
        /// Gets or Sets LegendOrientationThreshold
        /// </summary>
        [DataMember(Name = "legendOrientationThreshold", EmitDefaultValue = false)]
        public int? LegendOrientationThreshold { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MosaicViewProperties {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  TimeFormat: ").Append(TimeFormat).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Queries: ").Append(Queries).Append("\n");
            sb.Append("  Colors: ").Append(Colors).Append("\n");
            sb.Append("  Shape: ").Append(Shape).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
            sb.Append("  ShowNoteWhenEmpty: ").Append(ShowNoteWhenEmpty).Append("\n");
            sb.Append("  XColumn: ").Append(XColumn).Append("\n");
            sb.Append("  GenerateXAxisTicks: ").Append(GenerateXAxisTicks).Append("\n");
            sb.Append("  XTotalTicks: ").Append(XTotalTicks).Append("\n");
            sb.Append("  XTickStart: ").Append(XTickStart).Append("\n");
            sb.Append("  XTickStep: ").Append(XTickStep).Append("\n");
            sb.Append("  YLabelColumnSeparator: ").Append(YLabelColumnSeparator).Append("\n");
            sb.Append("  YLabelColumns: ").Append(YLabelColumns).Append("\n");
            sb.Append("  YSeriesColumns: ").Append(YSeriesColumns).Append("\n");
            sb.Append("  FillColumns: ").Append(FillColumns).Append("\n");
            sb.Append("  XDomain: ").Append(XDomain).Append("\n");
            sb.Append("  YDomain: ").Append(YDomain).Append("\n");
            sb.Append("  XAxisLabel: ").Append(XAxisLabel).Append("\n");
            sb.Append("  YAxisLabel: ").Append(YAxisLabel).Append("\n");
            sb.Append("  XPrefix: ").Append(XPrefix).Append("\n");
            sb.Append("  XSuffix: ").Append(XSuffix).Append("\n");
            sb.Append("  YPrefix: ").Append(YPrefix).Append("\n");
            sb.Append("  YSuffix: ").Append(YSuffix).Append("\n");
            sb.Append("  HoverDimension: ").Append(HoverDimension).Append("\n");
            sb.Append("  LegendColorizeRows: ").Append(LegendColorizeRows).Append("\n");
            sb.Append("  LegendHide: ").Append(LegendHide).Append("\n");
            sb.Append("  LegendOpacity: ").Append(LegendOpacity).Append("\n");
            sb.Append("  LegendOrientationThreshold: ").Append(LegendOrientationThreshold).Append("\n");
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
            return Equals(input as MosaicViewProperties);
        }

        /// <summary>
        /// Returns true if MosaicViewProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of MosaicViewProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MosaicViewProperties input)
        {
            if (input == null)
            {
                return false;
            }

            return base.Equals(input) &&
                   (
                       TimeFormat == input.TimeFormat ||
                       TimeFormat != null && TimeFormat.Equals(input.TimeFormat)
                   ) && base.Equals(input) &&
                   (
                       Type == input.Type ||
                       Type.Equals(input.Type)
                   ) && base.Equals(input) &&
                   (
                       Queries == input.Queries ||
                       Queries != null &&
                       Queries.SequenceEqual(input.Queries)
                   ) && base.Equals(input) &&
                   (
                       Colors == input.Colors ||
                       Colors != null &&
                       Colors.SequenceEqual(input.Colors)
                   ) && base.Equals(input) &&
                   (
                       Shape == input.Shape ||
                       Shape.Equals(input.Shape)
                   ) && base.Equals(input) &&
                   (
                       Note == input.Note ||
                       Note != null && Note.Equals(input.Note)
                   ) && base.Equals(input) &&
                   (
                       ShowNoteWhenEmpty == input.ShowNoteWhenEmpty ||
                       ShowNoteWhenEmpty != null && ShowNoteWhenEmpty.Equals(input.ShowNoteWhenEmpty)
                   ) && base.Equals(input) &&
                   (
                       XColumn == input.XColumn ||
                       XColumn != null && XColumn.Equals(input.XColumn)
                   ) && base.Equals(input) &&
                   (
                       GenerateXAxisTicks == input.GenerateXAxisTicks ||
                       GenerateXAxisTicks != null &&
                       GenerateXAxisTicks.SequenceEqual(input.GenerateXAxisTicks)
                   ) && base.Equals(input) &&
                   (
                       XTotalTicks == input.XTotalTicks ||
                       XTotalTicks != null && XTotalTicks.Equals(input.XTotalTicks)
                   ) && base.Equals(input) &&
                   (
                       XTickStart == input.XTickStart ||
                       XTickStart != null && XTickStart.Equals(input.XTickStart)
                   ) && base.Equals(input) &&
                   (
                       XTickStep == input.XTickStep ||
                       XTickStep != null && XTickStep.Equals(input.XTickStep)
                   ) && base.Equals(input) &&
                   (
                       YLabelColumnSeparator == input.YLabelColumnSeparator ||
                       YLabelColumnSeparator != null && YLabelColumnSeparator.Equals(input.YLabelColumnSeparator)
                   ) && base.Equals(input) &&
                   (
                       YLabelColumns == input.YLabelColumns ||
                       YLabelColumns != null &&
                       YLabelColumns.SequenceEqual(input.YLabelColumns)
                   ) && base.Equals(input) &&
                   (
                       YSeriesColumns == input.YSeriesColumns ||
                       YSeriesColumns != null &&
                       YSeriesColumns.SequenceEqual(input.YSeriesColumns)
                   ) && base.Equals(input) &&
                   (
                       FillColumns == input.FillColumns ||
                       FillColumns != null &&
                       FillColumns.SequenceEqual(input.FillColumns)
                   ) && base.Equals(input) &&
                   (
                       XDomain == input.XDomain ||
                       XDomain != null &&
                       XDomain.SequenceEqual(input.XDomain)
                   ) && base.Equals(input) &&
                   (
                       YDomain == input.YDomain ||
                       YDomain != null &&
                       YDomain.SequenceEqual(input.YDomain)
                   ) && base.Equals(input) &&
                   (
                       XAxisLabel == input.XAxisLabel ||
                       XAxisLabel != null && XAxisLabel.Equals(input.XAxisLabel)
                   ) && base.Equals(input) &&
                   (
                       YAxisLabel == input.YAxisLabel ||
                       YAxisLabel != null && YAxisLabel.Equals(input.YAxisLabel)
                   ) && base.Equals(input) &&
                   (
                       XPrefix == input.XPrefix ||
                       XPrefix != null && XPrefix.Equals(input.XPrefix)
                   ) && base.Equals(input) &&
                   (
                       XSuffix == input.XSuffix ||
                       XSuffix != null && XSuffix.Equals(input.XSuffix)
                   ) && base.Equals(input) &&
                   (
                       YPrefix == input.YPrefix ||
                       YPrefix != null && YPrefix.Equals(input.YPrefix)
                   ) && base.Equals(input) &&
                   (
                       YSuffix == input.YSuffix ||
                       YSuffix != null && YSuffix.Equals(input.YSuffix)
                   ) && base.Equals(input) &&
                   (
                       HoverDimension == input.HoverDimension ||
                       HoverDimension.Equals(input.HoverDimension)
                   ) && base.Equals(input) &&
                   (
                       LegendColorizeRows == input.LegendColorizeRows ||
                       LegendColorizeRows != null && LegendColorizeRows.Equals(input.LegendColorizeRows)
                   ) && base.Equals(input) &&
                   (
                       LegendHide == input.LegendHide ||
                       LegendHide != null && LegendHide.Equals(input.LegendHide)
                   ) && base.Equals(input) &&
                   (
                       LegendOpacity == input.LegendOpacity ||
                       LegendOpacity != null && LegendOpacity.Equals(input.LegendOpacity)
                   ) && base.Equals(input) &&
                   (
                       LegendOrientationThreshold == input.LegendOrientationThreshold ||
                       LegendOrientationThreshold != null &&
                       LegendOrientationThreshold.Equals(input.LegendOrientationThreshold)
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
                var hashCode = base.GetHashCode();

                if (TimeFormat != null)
                {
                    hashCode = hashCode * 59 + TimeFormat.GetHashCode();
                }

                hashCode = hashCode * 59 + Type.GetHashCode();
                if (Queries != null)
                {
                    hashCode = hashCode * 59 + Queries.GetHashCode();
                }

                if (Colors != null)
                {
                    hashCode = hashCode * 59 + Colors.GetHashCode();
                }

                hashCode = hashCode * 59 + Shape.GetHashCode();
                if (Note != null)
                {
                    hashCode = hashCode * 59 + Note.GetHashCode();
                }

                if (ShowNoteWhenEmpty != null)
                {
                    hashCode = hashCode * 59 + ShowNoteWhenEmpty.GetHashCode();
                }

                if (XColumn != null)
                {
                    hashCode = hashCode * 59 + XColumn.GetHashCode();
                }

                if (GenerateXAxisTicks != null)
                {
                    hashCode = hashCode * 59 + GenerateXAxisTicks.GetHashCode();
                }

                if (XTotalTicks != null)
                {
                    hashCode = hashCode * 59 + XTotalTicks.GetHashCode();
                }

                if (XTickStart != null)
                {
                    hashCode = hashCode * 59 + XTickStart.GetHashCode();
                }

                if (XTickStep != null)
                {
                    hashCode = hashCode * 59 + XTickStep.GetHashCode();
                }

                if (YLabelColumnSeparator != null)
                {
                    hashCode = hashCode * 59 + YLabelColumnSeparator.GetHashCode();
                }

                if (YLabelColumns != null)
                {
                    hashCode = hashCode * 59 + YLabelColumns.GetHashCode();
                }

                if (YSeriesColumns != null)
                {
                    hashCode = hashCode * 59 + YSeriesColumns.GetHashCode();
                }

                if (FillColumns != null)
                {
                    hashCode = hashCode * 59 + FillColumns.GetHashCode();
                }

                if (XDomain != null)
                {
                    hashCode = hashCode * 59 + XDomain.GetHashCode();
                }

                if (YDomain != null)
                {
                    hashCode = hashCode * 59 + YDomain.GetHashCode();
                }

                if (XAxisLabel != null)
                {
                    hashCode = hashCode * 59 + XAxisLabel.GetHashCode();
                }

                if (YAxisLabel != null)
                {
                    hashCode = hashCode * 59 + YAxisLabel.GetHashCode();
                }

                if (XPrefix != null)
                {
                    hashCode = hashCode * 59 + XPrefix.GetHashCode();
                }

                if (XSuffix != null)
                {
                    hashCode = hashCode * 59 + XSuffix.GetHashCode();
                }

                if (YPrefix != null)
                {
                    hashCode = hashCode * 59 + YPrefix.GetHashCode();
                }

                if (YSuffix != null)
                {
                    hashCode = hashCode * 59 + YSuffix.GetHashCode();
                }

                hashCode = hashCode * 59 + HoverDimension.GetHashCode();
                if (LegendColorizeRows != null)
                {
                    hashCode = hashCode * 59 + LegendColorizeRows.GetHashCode();
                }

                if (LegendHide != null)
                {
                    hashCode = hashCode * 59 + LegendHide.GetHashCode();
                }

                if (LegendOpacity != null)
                {
                    hashCode = hashCode * 59 + LegendOpacity.GetHashCode();
                }

                if (LegendOrientationThreshold != null)
                {
                    hashCode = hashCode * 59 + LegendOrientationThreshold.GetHashCode();
                }

                return hashCode;
            }
        }
    }
}