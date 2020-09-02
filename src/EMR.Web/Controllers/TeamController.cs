using Microsoft.AspNetCore.Mvc;

namespace EMR.Web.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Expend()
        {
            return View();
        }

        public IActionResult SalesQuota()
        {
            return View();
        }

        public IActionResult GiveOut()
        {
            return View();
        }
    }
}