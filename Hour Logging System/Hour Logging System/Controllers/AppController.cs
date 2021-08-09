using Hour_Logging_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Hour_Logging_System.Mongo;
using System.Collections.Generic;
using Hour_Logging_System.Sessions;

namespace Hour_Logging_System.Controllers
{
    public class AppController : Controller
    {

        public IActionResult Index()
        {
            if (HttpContext.Session.GetObject<IUser>("User") != null)
            {
                if (HttpContext.Session.GetString("UserMode") == "Manager")
                {
                    return RedirectToAction("Manager");
                }
                else
                {
                    return RedirectToAction("Employee");
                }
                
            }
            else
            {
                return RedirectToAction("EmployeeLogin");
            }

        }




        //Employee Application

        public IActionResult Employee()
        {
            return View();
        }

        public IActionResult EmployeeLogin()
        {//Load Login Page
            if (HttpContext.Session.GetObject<IUser>("User") == null)
            {
                return View();
                
            }
            else
            {
                return RedirectToAction("Index");
            }
        }





        //Manager Application


        public IActionResult Manager()
        {
            return View();
        }

        public IActionResult ManagerLogin()
        {//Load Login Page
            if (HttpContext.Session.GetObject<IUser>("User") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }




        public IActionResult Logout()
        {//Logout and return to main view.
            HttpContext.Session.SetObject("User", null);

            return RedirectToAction("Index");
        }







        public IActionResult SignUp()
        {//Load SignUp Page
            if (HttpContext.Session.GetObject<IUser>("User") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }

    //Session Extensions introduced in order to allow for Sessions to be stored as objects.
    
}
