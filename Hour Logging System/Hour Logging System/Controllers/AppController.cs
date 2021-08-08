using Hour_Logging_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Hour_Logging_System.Mongo;

namespace Hour_Logging_System.Controllers
{
    public class AppController : Controller
    {

        public IActionResult Index()
        {
            
            if (HttpContext.Session.GetObject<User>("User") != null)
            {
                return View(HttpContext.Session.GetObject<User>("User"));
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public IActionResult Login()
        {//Load Login Page
            if (HttpContext.Session.GetObject<User>("User") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult SignUp()
        {//Load SignUp Page
            return View();
        }
    }

    //Session Extensions introduced in order to allow for Sessions to be stored as objects.
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {//Sets the object of a session to Object
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {//Gets a session of known type (T)
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
