using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WhatsAppApiDotnet.Models.WhatsAppWebhook
{
    public class ChangeItem
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("item")]
        public string Item { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("created_time")]
        public long CreatedTime { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public class EntryItem
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("changes")]
        public IEnumerable<ChangeItem> Changes { get; set; }
    }

    public class WhatsAppWebhook
    {
        [JsonPropertyName("object")]
        public string Object { get; set; }

        [JsonPropertyName("entry")]
        public IEnumerable<EntryItem> Entry { get; set; }
    }
}
