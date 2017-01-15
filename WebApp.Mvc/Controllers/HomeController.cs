using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Mvc.Models;
using System.Text;
using Newtonsoft.Json;

namespace WebApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonpResult GetDataByJsonp(string key)
        {
            return this.Jsonp(new { Success = true, Data = "【From MvcApp Site】Hello, " + key, Message ="MvcApp Error"});
        }

       
    }
}