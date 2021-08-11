using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hour_Logging_System.Mongo;
using Hour_Logging_System.Encryption;
using Hour_Logging_System.Models;
using Hour_Logging_System.Sessions;
using System.Collections.Generic;

namespace Hour_Logging_System.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Login(string username, string password)
        {

            if (username != null && password != null)
            {
                username.Trim().ToLower();

                string hashedPassword = EasyMD5.Hash(password);

                MongoHandler db = new MongoHandler();

                Employee employee = new Employee() { 
                    Username = username, 
                    Password = hashedPassword
                };

                Employee user = db.Get(employee);

                if (user == null || user.Password != hashedPassword)
                {//return error - User not found
                    TempData["Error"] = "Sorry, Incorrect Username or Password";
                    TempData["Username"] = username;
                    return RedirectToAction("EmployeeLogin", "App");
                }
                else
                {
                    HttpContext.Session.SetObject("User", user);
                    HttpContext.Session.SetString("UserMode", "Employee");
                }
            }
            else
            {//Return error - Missing Username of Password
                TempData["Error"] = "Please enter both your Username and Password";
                TempData["Username"] = username;
                return RedirectToAction("EmployeeLogin", "App");
            }

            return RedirectToAction("Index", "App");
        }

        public IActionResult SignUp(string firstName, string lastName, string username, string company, string password)
        {
            username.Trim().ToLower();

            string hashedPassword = EasyMD5.Hash(password);

            MongoHandler db = new MongoHandler();

            Employee employee = new Employee() {
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                Password = hashedPassword,
                Company = company,
                Hours = new List<Hours>()
            };

            Employee user = db.Get(employee);

            if (user == null)
            {
                db.Insert(employee);
                Login(username, password);

            }
            else
            {
                TempData["Error"] = "Sorry, Username is taken. Try another combination";
                TempData["FirstName"] = username;
                TempData["LastName"] = username;
                TempData["Username"] = username;
                TempData["Company"] = company;
                return RedirectToAction("SignUp", "App");
            }

            return RedirectToAction("Index", "App");

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
