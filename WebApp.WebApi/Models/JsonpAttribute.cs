using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace WebApp.WebApi.Models
{
    public class JsonpAttribute : ActionFilterAttribute
    {
        private const string JsonpCallbackName = "callback";
        private const string CallbackApplicationType = "application/json";

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            string callback;

            if (IsJsonp(out callback))
            {
                var jsonBuilder = new StringBuilder(callback);

                jsonBuilder.AppendFormat("({0})", context.Response.Content.ReadAsStringAsync().Result);

                context.Response.Content = new StringContent(jsonBuilder.ToString());
                context.Response.Content.Headers.ContentType = new MediaTypeHeaderValue(CallbackApplicationType);
            }

            base.OnActionExecuted(context);
        }

        private bool IsJsonp(out string callback)
        {
            callback = HttpContext.Current.Request.QueryString[JsonpCallbackName];

            return !string.IsNullOrEmpty(callback);
        } 
    }
}