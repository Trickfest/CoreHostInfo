using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System;

namespace CoreHostInfo.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        // GET api/tcpconn
        [HttpGet("{address}")]
        public string Get([FromRoute] string address)
        {
            string r = Ping(address);
            return JsonConvert.SerializeObject(new { result = r }); ;
        }

        private static string Ping(string address)
        {
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(address);
                return reply.Status.ToString();
            }
            catch (PingException e)
            {
                return e.ToString();
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }
        }
    }
}
