using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CoreHostInfo.Controllers
{


    [Route("api/[controller]")]
    public class HostingEnvironmentController
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HostingEnvironmentController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET api/hostingenvironment
        [HttpGet]
        public object Get()
        {
            var results = new
            {
                ApplicationName = _hostingEnvironment.ApplicationName,
                ContentRootPath = _hostingEnvironment.ContentRootPath,
                EnvironmentName = _hostingEnvironment.EnvironmentName,
                WebRootPath = _hostingEnvironment.WebRootPath,
                RuntimeDirectory = RuntimeEnvironment.GetRuntimeDirectory(),
                SystemVersion = RuntimeEnvironment.GetSystemVersion(),
                FrameworkDescription = RuntimeInformation.FrameworkDescription
            };
            
            return results;
        }
    }
}