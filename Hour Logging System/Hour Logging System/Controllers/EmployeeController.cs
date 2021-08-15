using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hour_Logging_System.Mongo;
using Hour_Logging_System.Encryption;
using Hour_Logging_System.Models;
using Hour_Logging_System.Sessions;
using System.Collections.Generic;
using System;

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

        public IActionResult SignUp(string firstName, string lastName, string company, string username, string password)
        {
            firstName.Trim();
            lastName.Trim();
            company.Trim();
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
                TempData["FirstName"] = firstName;
                TempData["LastName"] = lastName;
                TempData["Username"] = username;
                TempData["Company"] = company;
                return RedirectToAction("SignUp", "App");
            }

            return RedirectToAction("Index", "App");

        }

        public IActionResult ClockIn()
        {
            //Refresh the employee in order to ensure that they have not already clocked in somewhere else.
            SessionManager sessionManager = new SessionManager();
            Employee user = sessionManager.ReloadUser(HttpContext.Session.GetObject<Employee>("User"));
            
            Hours previousSession;

            if (user.Hours.Count > 0)
            {
                 previousSession = user.Hours[user.Hours.Count - 1];
            }
            else
            {
                previousSession = new Hours()
                {
                    End = new DateTime()
                };
            }

            
            
            if (previousSession.End != null)
            {

                //Clock in
                user.Hours.Add(new Hours()
                {
                    Start = System.DateTime.Now
                });

                //Push to DB
                MongoHandler db = new MongoHandler();
                db.Update(user);
                HttpContext.Session.SetObject("User", user);

                return RedirectToAction("Index", "App");
            }
            else
            {
                TempData["Error"] = "User is already Clocked in... Unable to process request.";
                return RedirectToAction("Index", "App");
            }
            
            
            
        }
        public IActionResult ClockOut()
        {
            
        }


        
    }
}
