using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CommonAlertingServer.Models.Alerts.Dwd
{
	public enum Severity
	{
		[XmlEnum("Minor")]
		Minor = 0,
		[XmlEnum("Moderate")]
		Moderate = 1,
		[XmlEnum("Severe")]
		Severe = 2,
		[XmlEnum("Extreme")]
		Extreme = 3
	}

	public enum Urgency
	{
		[XmlEnum("Immediate")]
		Immediate = 0,
		[XmlEnum("Future")]
		Future = 1
	}

	public enum Category
    {
		[XmlEnum("Met")]
		Met = 0,
		[XmlEnum("Health")]
		Health = 1
	}

	public enum AlertStatus
	{
		[XmlEnum("Actual")]
		Actual = 0,
		[XmlEnum("Test")]
		Test = 1
	}

	public enum MsgType
    {
		[XmlEnum("Alert")]
		Alert = 0,
		[XmlEnum("Update")]
		Update = 1,
		[XmlEnum("Cancel")]
		Cancel = 2
	}

	public enum Certainty
	{
		[XmlEnum("Observed")]
		Observed = 0,
		[XmlEnum("Likely")]
		Likely = 1
	}

	[XmlRoot(ElementName = "Warnungen_Gemeinden", Namespace = "http://www.dwd.de")]
	public class DwdAlert
	{
		[JsonPropertyName("areaDesc")]
		[XmlElement(ElementName = "AREADESC", Namespace = "http://www.dwd.de")]
		public string AreaDesc { get; set; }

		[JsonPropertyName("Name")]
		[XmlElement(ElementName = "NAME", Namespace = "http://www.dwd.de")]
		public string Name { get; set; }

		[JsonPropertyName("warncellId")]
		[XmlElement(ElementName = "WARNCELLID", Namespace = "http://www.dwd.de")]
		public string WarnCellId { get; set; }
		
		[JsonPropertyName("identifier")]
		[XmlElement(ElementName = "IDENTIFIER", Namespace = "http://www.dwd.de")]
		public string Identifier { get; set; }

		[JsonPropertyName("sender")]
		[XmlElement(ElementName = "SENDER", Namespace = "http://www.dwd.de")]
		public string Sender { get; set; }

		[JsonPropertyName("sent")]
		[XmlElement(ElementName = "SENT", Namespace = "http://www.dwd.de")]
		public DateTime? Sent { get; set; }

		[JsonPropertyName("status")]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		[XmlElement(ElementName = "STATUS", Namespace = "http://www.dwd.de")]
		public AlertStatus? Status { get; set; }

		[JsonPropertyName("msgType")]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		[XmlElement(ElementName = "MSGTYPE", Namespace = "http://www.dwd.de")]
		public MsgType? MsgType { get; set; }

		[JsonPropertyName("source")]
		[XmlElement(ElementName = "SOURCE", Namespace = "http://www.dwd.de")]
		public string Source { get; set; }

		[JsonPropertyName("scope")]
		[XmlElement(ElementName = "SCOPE", Namespace = "http://www.dwd.de")]
		public string Scope { get; set; }

		[JsonPropertyName("code")]
		[XmlElement(ElementName = "CODE", Namespace = "http://www.dwd.de")]
		public string Code { get; set; }

		[JsonPropertyName("language")]
		[XmlElement(ElementName = "LANGUAGE", Namespace = "http://www.dwd.de")]
		public string Language { get; set; }

		[JsonPropertyName("category")]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		[XmlElement(ElementName = "CATEGORY", Namespace = "http://www.dwd.de")]
		public Category? Category { get; set; }

		[JsonPropertyName("event")]
		[XmlElement(ElementName = "EVENT", Namespace = "http://www.dwd.de")]
		public string Event { get; set; }

		[JsonPropertyName("responseType")]
		[XmlElement(ElementName = "RESPONSETYPE", Namespace = "http://www.dwd.de")]
		public string ResponseType { get; set; }

		[JsonPropertyName("urgency")]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		[XmlElement(ElementName = "URGENCY", Namespace = "http://www.dwd.de")]
		public Urgency? Urgency { get; set; }

		[JsonPropertyName("severity")]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		[XmlElement(ElementName = "SEVERITY", Namespace = "http://www.dwd.de")]
		public Severity? Severity { get; set; }

		[JsonPropertyName("certainty")]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		[XmlElement(ElementName = "CERTAINTY", Namespace = "http://www.dwd.de")]
		public Certainty? Certainty { get; set; }

		[JsonPropertyName("effective")]
		[XmlElement(ElementName = "EFFECTIVE", Namespace = "http://www.dwd.de")]
		public string Effective { get; set; }

		[JsonPropertyName("onSet")]
		[XmlElement(ElementName = "ONSET", Namespace = "http://www.dwd.de")]
		public DateTime? OnSet { get; set; }

		[JsonPropertyName("expires")]
		[XmlElement(ElementName = "EXPIRES", Namespace = "http://www.dwd.de")]
		public DateTime? Expires { get; set; }

		[JsonPropertyName("senderName")]
		[XmlElement(ElementName = "SENDERNAME", Namespace = "http://www.dwd.de")]
		public string SenderName { get; set; }

		[JsonPropertyName("headline")]
		[XmlElement(ElementName = "HEADLINE", Namespace = "http://www.dwd.de")]
		public string Headline { get; set; }

		[JsonPropertyName("description")]
		[XmlElement(ElementName = "DESCRIPTION", Namespace = "http://www.dwd.de")]
		public string Description { get; set; }

		[JsonPropertyName("web")]
		[XmlElement(ElementName = "WEB", Namespace = "http://www.dwd.de")]
		public string Web { get; set; }

		[JsonPropertyName("contact")]
		[XmlElement(ElementName = "CONTACT", Namespace = "http://www.dwd.de")]
		public string Contact { get; set; }

		[JsonPropertyName("altitude")]
		[XmlElement(ElementName = "ALTITUDE", Namespace = "http://www.dwd.de")]
		public string Altitude { get; set; }

		[JsonPropertyName("ceiling")]
		[XmlElement(ElementName = "CEILING", Namespace = "http://www.dwd.de")]
		public string Ceiling { get; set; }

		[JsonPropertyName("id")]
		[XmlAttribute(AttributeName = "id", Namespace = "http://www.opengis.net/gml/3.2")]
		public string Id { get; set; }

		[JsonPropertyName("instruction")]
		[XmlElement(ElementName = "INSTRUCTION", Namespace = "http://www.dwd.de")]
		public string Instruction { get; set; }

		[JsonPropertyName("parameterName")]
		[XmlElement(ElementName = "PARAMETERNAME", Namespace = "http://www.dwd.de")]
		public string ParameterName { get; set; }

		[JsonPropertyName("paramterValue")]
		[XmlElement(ElementName = "PARAMETERVALUE", Namespace = "http://www.dwd.de")]
		public string ParameterValue { get; set; }
	}
}
