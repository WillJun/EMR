using Microsoft.AspNetCore.Mvc;

namespace EMR.Web.Controllers
{
    public class ExchargeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}