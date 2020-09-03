using Microsoft.AspNetCore.Mvc;

namespace EMR.Web.Controllers
{
    public class AcountController : Controller
    {
        public IActionResult Index(string backUrl = "")
        {
            ViewBag.BackUrl = backUrl;
            return View();
        }
    }
}