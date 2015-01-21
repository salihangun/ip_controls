using System.Web.Mvc;
using System.Net.NetworkInformation;
namespace ip_control.Controllers
{
    public class HomeController : BaseController
    {

        [HttpGet]
        public ViewResult Index()
        {

            return View();
        }

        [HttpPost]
        public string KontrolEt(string ip)
        {
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(ip);
            if (pingReply.Status == IPStatus.Success)
            {
                // server ip adresini verir.
                return "ok";
            }
            else
            {
                return "fail";
            }
        }

    }
}
