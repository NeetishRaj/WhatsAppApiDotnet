using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {

        public PingController()
        {
        }

        [HttpGet]
        public Object Get()
        {
            return Ok("API is live and responsive!");
        }
    }
}
