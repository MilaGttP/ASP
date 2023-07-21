
using Microsoft.AspNetCore.Mvc;

namespace ASP
{
    public class GettimesuniversalController : Controller
    {
        public IActionResult GetUtcTimes()
        {
            return Content($"GetUtcTimes: {DateTime.UtcNow.ToString()}");
        }


        //GetCurrentTimes (date): /Gettimesuniversal/GetCurrentTimes?parameter=d
        //GetCurrentTimes (time): /Gettimesuniversal/GetCurrentTimes?parameter=t
        //GetCurrentTimes (date and time): /Gettimesuniversal/GetCurrentTimes

        public IActionResult GetCurrentTimes(char parameter)
        {
            if (parameter == 'd')
            {
                return Content($"GetCurrentTimes (date): {DateTime.Now.ToShortDateString()}");
            }
            else if (parameter == 't')
            {
                return Content($"GetCurrentTimes (time): {DateTime.Now.ToShortTimeString()}");
            }
            else
            {
                return Content($"GetCurrentTimes (date and time): {DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")}");
            }
        }
    }
}
