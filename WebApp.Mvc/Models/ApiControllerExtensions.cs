using System.Web.Mvc;

namespace WebApp.Mvc.Models
{
    public static class ApiControllerExtensions
    {
        public static JsonpResult Jsonp(this Controller controller, object data)
        {
            var result = new JsonpResult
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            return result;
        } 
    }
}