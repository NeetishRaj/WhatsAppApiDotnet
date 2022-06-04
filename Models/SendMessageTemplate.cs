using System;
using System.Text.Json.Serialization;

namespace Models
{
    public class Language
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public class Template
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("language")]
        public Language Language { get; set; }
    }

    public class SendMessageTemplate
    {
        public SendMessageTemplate() {
            this.MessagingProduct = "whatsapp";
            this.Type = "template";

            this.Template = new Template {
                Language = new Language { Code = "en_US"}
            };
        }
        
        [JsonPropertyName("messaging_product")]
        public string MessagingProduct { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("template")]
        public Template Template { get; set; }
    }
}
