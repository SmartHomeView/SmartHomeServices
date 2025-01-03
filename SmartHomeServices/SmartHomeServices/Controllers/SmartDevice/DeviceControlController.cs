using Microsoft.AspNetCore.Mvc;

namespace SmartHomeServices.Controllers.SmartDevice
{
    public class DeviceControlController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
