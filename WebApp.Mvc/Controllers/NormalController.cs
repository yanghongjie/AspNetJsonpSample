using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebApp.Mvc.Controllers
{
    public class NormalController : Controller
    {
        public JavaScriptResult GetDataByJsonp()
        {
            var key = Request.QueryString["key"];

            var cb = Request.QueryString["callback"];

            var data = new { Success = true, Data = "【From MvcApp Site】Hello, " + key, Message = "MvcApp Error" };

            var jsonBuilder = new StringBuilder(cb);

            jsonBuilder.AppendFormat("({0})", JsonConvert.SerializeObject(data));

            return JavaScript(jsonBuilder.ToString());
        }
    }
}