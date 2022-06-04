using System;
using System.Text.Json.Serialization;

namespace WhatsAppApiDotnet.Models.SendTextMessage
{
    public class Text
    {
        [JsonPropertyName("body")]
        public string Body { get; set; }
    }

    public class SendTextMessage
    {
        public SendTextMessage()
        {
            MessagingProduct = "whatsapp";
            PreviewUrl = false;
            RecipientType = "individual";
            Type = "text";
            Text = new Text();
        }

        [JsonPropertyName("messaging_product")]
        public string MessagingProduct { get; set; }

        [JsonPropertyName("preview_url")]
        public bool PreviewUrl { get; set; }

        [JsonPropertyName("recipient_type")]
        public string RecipientType { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("text")]
        public Text Text { get; set; }
    }
}
