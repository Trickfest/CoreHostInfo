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
    public class TcpConnController : Controller
    {
        // GET api/tcpconn
        [HttpGet("{address}/{port}")]
        public string Get([FromRoute] string address, [FromRoute] int port)
        {
            IPAddress ipAddressDns;
            IPAddress ipAddressIp;

            string DnsResult = OpenSocketDNS(address, port, out ipAddressDns) ? "Success" : "Failure";
            string IpResult = OpenSocketIP(address, port, out ipAddressIp) ? "Success" : "Failure";
            return JsonConvert.SerializeObject(new
            {
                DnsResult = DnsResult,
                DnsTargetIp = (ipAddressDns == null) ? "null" : ipAddressDns.ToString(),
                IpResult = IpResult,
                ParsedIp = (ipAddressIp == null) ? "null" : ipAddressIp.ToString()
            }); ;
        }

        private static bool OpenSocketDNS(string address, int port, out IPAddress ipAddress)
        {
            ipAddress = null;

            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(address);

                if (hostEntry.AddressList.Length <= 0)
                {
                    return false;
                }
                else
                {
                    ipAddress = hostEntry.AddressList[0]; // use first ip, ignoring any others
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                    // Create a TCP/IP socket.  
                    Socket sender = new Socket(ipAddress.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);

                    sender.Connect(remoteEP);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool OpenSocketIP(string address, int port, out IPAddress ipAddress)
        {
            ipAddress = null;

            try
            {
                ipAddress = IPAddress.Parse(address);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(remoteEP);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
