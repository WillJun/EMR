﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace EMR.Web.Controllers
{
    public class AcountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
