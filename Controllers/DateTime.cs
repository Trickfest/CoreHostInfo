using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreHostInfo.Controllers
{
    [Route("api/[controller]")]
    public class DateTimeController : Controller
    {
        // GET api/datetime
        [HttpGet]
        public string Get()
        {
            var now = DateTime.Now;        
                
            return JsonConvert.SerializeObject(new { date = now.ToLongDateString(), time = now.ToLongTimeString() });
        }
    }
}
