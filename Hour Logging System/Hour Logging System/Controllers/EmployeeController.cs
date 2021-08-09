using Microsoft.AspNetCore.Mvc;
using Hour_Logging_System.Mongo;
using Hour_Logging_System.Encryption;
using Hour_Logging_System.Models;
using Hour_Logging_System.Sessions;

namespace Hour_Logging_System.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Login(string username, string password)
        {
            

            if (username != null && password != null)
            {
                username.Trim().ToLower();

                string HashedPassword = EasyMD5.Hash(password);

                MongoHandler db = new MongoHandler();

                Employee employee = new Employee() { Username = username, Password = HashedPassword };

                Employee user = db.Get(employee);

                if (user == null)
                {//return error - User not found
                    return RedirectToAction("EmployeeLogin", "App");
                    
                }
                else
                {
                    HttpContext.Session.SetObject("User", user);
                }
            }
            else
            {//Return error - Missing Username of Password
                ViewBag.Error = new Error { ErrorMessage = "Missing Credentials" };
                return RedirectToAction("EmployeeLogin", "App");
            }

            return RedirectToAction("Index", "App");
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
