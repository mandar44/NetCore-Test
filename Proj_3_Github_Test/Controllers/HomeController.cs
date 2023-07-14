using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Proj_3_Github_Test.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //return "Welcome to Controller";
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtUserName,string txtPassword)
        {


            return RedirectToAction("Index", "RedisTest");

        }

    }
}
