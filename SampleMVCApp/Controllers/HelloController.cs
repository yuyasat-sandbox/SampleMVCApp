using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleMVCApp.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Message"] = "Input your data:";
            ViewData["name"] = "";
            ViewData["mail"] = "";
            ViewData["tel"] = "";
            return View();
        }

        [HttpPost]
        public IActionResult Form(string name, string mail, string tel)
        {
            ViewData["name"] = name;
            ViewData["mail"] = mail;
            ViewData["tel"] = tel;
            ViewData["message"] = ViewData["name"] + ", " + ViewData["mail"] + ", " + ViewData["tel"];
            return View("Index");
        }
    }
}

