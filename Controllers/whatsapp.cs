using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Models;

namespace WhatsAppApiDotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WhatsAppController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        private readonly ILogger<WhatsAppController> _logger;

        private readonly IConfiguration _configuration;
        private readonly WhatsAppConfig _waConfigs;

        public WhatsAppController(
            ILogger<WhatsAppController> logger,
            IConfiguration configuration
        )
        {
            _logger = logger;
            _configuration = configuration;
            _waConfigs = new WhatsAppConfig();
            _configuration.GetSection("WhatsApp").Bind(_waConfigs);

            // Setup the HttpClient headers
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer",_waConfigs.AccessToken);
            client
                .DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string GetUrl()
        {
            // Example: https://graph.facebook.com/v13.0/10938439232/messages
            return $"{_waConfigs.BaseUrl}/{_waConfigs.ApiVersion}/{_waConfigs.AppID}/messages";
        }

        [HttpPost]
        [Route("template")]
        public async Task<Object>
        SendMessageUsingTemplate(SendMessageTemplate message)
        {
            var content =
                new StringContent(JsonSerializer.Serialize(message),
                    Encoding.UTF8,
                    "application/json");

            var result = await client.PostAsync(GetUrl(), content);

            return Ok(result);
        }

        [HttpPost]
        [Route("text")]
        public async Task<Object> SendDirectTextMessage(SendTextMessage message)
        {
            var content =
                new StringContent(JsonSerializer.Serialize(message),
                    Encoding.UTF8,
                    "application/json");

            var result = await client.PostAsync(GetUrl(), content);

            return Ok(result);
        }
    }
}
