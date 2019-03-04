using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreHostInfo.Controllers
{
    [Route("api/[controller]")]
    public class VersionController : Controller
    {
        // GET api/version
        [HttpGet]
        public string Get() => JsonConvert.SerializeObject(new { version = "20190304.2" });
    }
}