using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CommonAlertingServer.Models.Alerts.Dwd
{
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
		public string Sent { get; set; }

		[JsonPropertyName("status")]
		[XmlElement(ElementName = "STATUS", Namespace = "http://www.dwd.de")]
		public string Status { get; set; }

		[JsonPropertyName("msgType")]
		[XmlElement(ElementName = "MSGTYPE", Namespace = "http://www.dwd.de")]
		public string MsgType { get; set; }

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
		[XmlElement(ElementName = "CATEGORY", Namespace = "http://www.dwd.de")]
		public string Category { get; set; }

		[JsonPropertyName("event")]
		[XmlElement(ElementName = "EVENT", Namespace = "http://www.dwd.de")]
		public string Event { get; set; }

		[JsonPropertyName("responseType")]
		[XmlElement(ElementName = "RESPONSETYPE", Namespace = "http://www.dwd.de")]
		public string ResponseType { get; set; }

		[JsonPropertyName("urgency")]
		[XmlElement(ElementName = "URGENCY", Namespace = "http://www.dwd.de")]
		public string Urgency { get; set; }

		[JsonPropertyName("severity")]
		[XmlElement(ElementName = "SEVERITY", Namespace = "http://www.dwd.de")]
		public string Severity { get; set; }

		[JsonPropertyName("certainty")]
		[XmlElement(ElementName = "CERTAINTY", Namespace = "http://www.dwd.de")]
		public string Certainty { get; set; }

		[JsonPropertyName("effective")]
		[XmlElement(ElementName = "EFFECTIVE", Namespace = "http://www.dwd.de")]
		public string Effective { get; set; }

		[JsonPropertyName("onSet")]
		[XmlElement(ElementName = "ONSET", Namespace = "http://www.dwd.de")]
		public string OnSet { get; set; }

		[JsonPropertyName("expires")]
		[XmlElement(ElementName = "EXPIRES", Namespace = "http://www.dwd.de")]
		public string Expires { get; set; }

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
