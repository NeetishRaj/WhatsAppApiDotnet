using System;
using Microsoft.AspNetCore.Mvc;

namespace WhatsAppApiDotnet.Controllers.Ping
{
    [ApiController]
    [Route("ping")]
    public class PingController : ControllerBase
    {
        public PingController()
        {
        }

        [HttpGet]
        public object Get()
        {
            return Ok("API is live and responsive!");
        }
    }
}
