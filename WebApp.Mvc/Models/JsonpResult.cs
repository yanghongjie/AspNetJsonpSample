using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebApp.Mvc.Models
{
    public class JsonpResult : JsonResult
    {
        private const string JsonpCallbackName = "callback";
        private const string CallbackApplicationType = "application/json";

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if ((JsonRequestBehavior == JsonRequestBehavior.DenyGet) &&
                  String.Equals(context.HttpContext.Request.HttpMethod, "GET"))
            {
                throw new InvalidOperationException();
            }
            var response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : CallbackApplicationType;
            if (ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (Data != null)
            {
                var request = context.HttpContext.Request;
                var serializer = new JavaScriptSerializer();
                string buffer = request[JsonpCallbackName] != null ? String.Format("{0}({1})", request[JsonpCallbackName], serializer.Serialize(Data)) : serializer.Serialize(Data);
                response.Write(buffer);
            }
        }
    }
}