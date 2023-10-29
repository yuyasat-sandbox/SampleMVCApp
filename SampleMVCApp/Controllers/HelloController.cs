using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

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
            HttpContext.Session.SetInt32("id", id);
            Console.WriteLine("Hello, " + name);
            HttpContext.Session.SetString("name", name);
            MyData ob = new MyData(id, name);
            String s = ObjectToString(ob);
            HttpContext.Session.SetString("object", s);
            ViewData["object"] = ob;
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

        [HttpGet("Other")]
        public IActionResult Other()
        {
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            ViewData["name"] = HttpContext.Session.GetString("name");
            ViewData["message"] = "保存されたセッションの値を表示します。";
            String s = HttpContext.Session.GetString("object") ?? "";
            ViewData["object"] = StringToObject(s);
            return View();
        }

        private String ObjectToString(MyData ob)
        {
            return JsonSerializer.Serialize<MyData>(ob);
        }

        private MyData? StringToObject(String s)
        {
            MyData? ob;
            try
            {
                ob = JsonSerializer.Deserialize<MyData>(s);

            }
            catch (Exception e)
            {
                ob = new MyData(0, "noname");
            }

            return ob;
        }
    }
}

[Serializable]
class MyData
{
    public int Id { get; set; }
    public string Name { get; set; }

    public MyData(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public override string ToString()
    {
        return "<" + Id + ": " + Name + ">";
    }
}
