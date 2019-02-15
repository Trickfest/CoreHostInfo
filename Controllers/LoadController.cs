using System;
using System.Threading;
//using CoreHostInfo.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreHostInfo.Controllers
{
    [Route("api/[controller]")]
    public class LoadController : Controller
    {
        // GET api/hostingenvironment
        [HttpGet]
        public WorkResults Get(string requestId, int blobSize, int delay)
        {
            // sanity check arguments
            delay = (delay < 0) ? -1 : delay;
            blobSize = (blobSize < 1) ? 1 : blobSize;

            if (delay >= 0)
            {
                Thread.Sleep(delay);
            }

            WorkResults wr = new WorkResults()
            {
                RequestTimeStamp = DateTime.Now.ToString(),
                RequestId = string.IsNullOrWhiteSpace(requestId) ? Guid.NewGuid().ToString() : requestId,
                Delay = delay,
                BlobSize = blobSize,
                Blob = new string('x', blobSize)
            };

            return wr;
        }
    }

    public class WorkResults
    {
        public string RequestTimeStamp { get; set; }

        public string RequestId { get; set; }

        public int Delay { get; set; }

        public int BlobSize { get; set; }

        public string Blob { get; set; }
    }
}

