using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreHostInfo.Controllers
{
    [Route("api/[controller]")]
    public class MyIpController : Controller
    {
        // GET api/myip
        [HttpGet]
        public string Get()
        {
            var remoteIp = Request.HttpContext.Connection.RemoteIpAddress;            
            
            return JsonConvert.SerializeObject(new { remoteip = remoteIp.ToString() });
        }
    }
}
