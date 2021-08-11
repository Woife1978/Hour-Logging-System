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
            if (HttpContext.Session.GetString("User") != null)
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
            if (
                HttpContext.Session.GetString("User") != null && 
                HttpContext.Session.GetString("UserMode") == "Employee"
                )
            {
                return View(HttpContext.Session.GetObject<Employee>("User"));
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult EmployeeLogin()
        {//Load Login Page
            if (HttpContext.Session.GetString("User") == null)
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
            if (HttpContext.Session.GetString("User") == null)
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
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }







        public IActionResult SignUp()
        {//Load SignUp Page
            if (HttpContext.Session.GetString("User") == null)
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
