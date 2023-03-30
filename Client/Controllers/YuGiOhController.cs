using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class YuGiOhController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
