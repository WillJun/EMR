﻿using Microsoft.AspNetCore.Mvc;

namespace EMR.Web.Controllers
{
    public class WowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}