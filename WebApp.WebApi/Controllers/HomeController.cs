using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApp.WebApi.Models;

namespace WebApp.WebApi.Controllers
{
    public class HomeController : ApiController
    {
        [Jsonp]
        public object GetDataByJsonp(string key)
        {
            return new { Success = true, Data = "【From WebApi Site】Hello, " + key, Message = "WebApi Error" };
        }

    }
}
