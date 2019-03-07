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
            return JsonConvert.SerializeObject(new { remoteip = Request.HttpContext.Connection.RemoteIpAddress.ToString() });
        }
    }
}
