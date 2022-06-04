using System;
using System.Text.Json.Serialization;

namespace Models
{
    public class WhatsAppConfig
    {
        public string AppID { get; set; }
        public string AccessToken { get; set; }
        public string ApiVersion { get; set; }
        public string BaseUrl { get; set; }

    }
}
