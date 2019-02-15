using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace CoreHostInfo.Controllers
{
    [Route("api/[controller]")]
    public class EnvironmentController : Controller
    {
        // GET api/environment
        [HttpGet]
        public IDictionary Get()
        {
            return Environment.GetEnvironmentVariables();
        }
    }
}