using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Text;
using Newtonsoft.Json;

namespace WebApp.WebApi.Controllers
{
    public class NormalController : ApiController
    {
        public IHttpActionResult GetDataByJsonp(string key)
        {

            var cb = HttpContext.Current.Request.QueryString["callback"];

            var data = new { Success = true, Data = "【From WebApi Site】Hello, " + key, Message = "WebApi Error" };

            var jsonBuilder = new StringBuilder(cb);

            jsonBuilder.AppendFormat("({0})", JsonConvert.SerializeObject(data));

            HttpContext.Current.Response.Write(jsonBuilder.ToString());

            return Ok();
        }
    }
}
