using System;
using System.Net.Http;
using System.Text;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WhatsAppApiDotnet.Models.SendTextMessage;
using WhatsAppApiDotnet.Models.WhatsAppConfig;
using WhatsAppApiDotnet.Models.WhatsAppWebhook;

namespace WhatsAppApiDotnet.Controllers.Webhook
{
    [ApiController]
    [Route("webhook")]
    public class WebhookController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        private readonly IConfiguration _configuration;

        private readonly WhatsAppConfig _waConfig;

        public WebhookController(IConfiguration configuration)
        {
            _configuration = configuration;
            _waConfig = new WhatsAppConfig();
            _configuration.GetSection("WhatsApp").Bind(_waConfig);
        }

        [HttpGet]
        public object GetWebHook()
        {
            return Ok("Webhooks endpoint!");
        }

        private string GetUrl()
        {
            // Example: https://graph.facebook.com/v13.0/10938439232/messages
            return $"{_waConfig.BaseUrl}/{_waConfig.ApiVersion}/{_waConfig.AppID}/messages";
        }

        [HttpPost]
        public async Task<Object> PostWebhookEvents(WhatsAppWebhook data)
        {
            if (data != null && data.Entry != null)
            {
                var message = data.Entry.First().Changes.First().Message;

                var response = new SendTextMessage();
                response.To = _waConfig.MyWhatsappNo;
                response.Text.Body = $"Your message was {message}";
                var content =
                    new StringContent(JsonSerializer.Serialize(response),
                        Encoding.UTF8,
                        "application/json");

                var result = await client.PostAsync(GetUrl(), content);
            }

            return Ok();
        }
    }
}
