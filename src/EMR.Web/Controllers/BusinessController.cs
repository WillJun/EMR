
using Microsoft.AspNetCore.Mvc;

namespace EMR.Web.Controllers
{
    public class BusinessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Custom()
        {
            return View();
        }
    }
}
