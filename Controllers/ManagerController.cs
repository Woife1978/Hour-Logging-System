﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hour_Logging_System.Controllers
{
    public class ManagerController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
