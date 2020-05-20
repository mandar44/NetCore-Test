using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Proj_3_Github_Test.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome to Controller";
        }
    }
}
