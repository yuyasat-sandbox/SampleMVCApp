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
        public List<string> list;

        public HelloController()
        {
            list = new List<string>();
            list.Add("Japan");
            list.Add("USA");
            list.Add("UK");
        }

        [Route("hello/{id?}/{name?}")]
        public IActionResult Index(int id, string name)
        {
            // ViewData["Message"] = "Input your data:";
            ViewData["Message"] = "id = " + id + ", name = " + name;
            ViewData["name"] = "";
            ViewData["mail"] = "";
            ViewData["tel"] = "";
            ViewData["list"] = "";
            ViewData["listdata"] = list;
            return View();
        }

        [HttpPost]
        public IActionResult Form(string name, string mail, string tel)
        {
            ViewData["name"] = name;
            ViewData["mail"] = mail;
            ViewData["tel"] = tel;
            ViewData["message"] = ViewData["name"] + ", " + ViewData["mail"] + ", " + ViewData["tel"]
                + ", " + Request.Form["list"] + " selected.";
            ViewData["list"] = Request.Form["list"][0];
            ViewData["listdata"] = list;
            return View("Index");
        }
    }
}

