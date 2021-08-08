using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hour_Logging_System.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult Pay()
        {
            return View();
        }

        public IActionResult ClockIn()
        {
            return View();
        }
        public IActionResult ClockOut()
        {
            return View();
        }
    }
}
