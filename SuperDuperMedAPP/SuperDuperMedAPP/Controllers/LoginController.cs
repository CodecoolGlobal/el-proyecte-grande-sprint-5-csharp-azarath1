using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Controllers
{
    public class LoginController : Controller
    {
        private const string SessionKeyName = "_Name";
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            if (Username == "hello@world.com" && Password == "pass")
            {
                HttpContext.Session.SetString(SessionKeyName, Username);
                return View("Views/User/Index.cshtml");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
