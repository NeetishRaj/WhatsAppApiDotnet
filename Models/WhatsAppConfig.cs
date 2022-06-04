using System;
using System.Text.Json.Serialization;

namespace WhatsAppApiDotnet.Models.WhatsAppConfig
{
    public class WhatsAppConfig
    {
        public string AppID { get; set; }

        public string AccessToken { get; set; }

        public string ApiVersion { get; set; }

        public string BaseUrl { get; set; }

        public string MyWhatsappNo { get; set; }
    }
}
