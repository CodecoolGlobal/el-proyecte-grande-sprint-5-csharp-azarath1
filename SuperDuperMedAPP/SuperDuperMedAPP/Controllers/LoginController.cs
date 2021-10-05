using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            if (Email == "hello@world.com" && Password == "pass")
            {
                return View("Views/User/Index.cshtml");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
