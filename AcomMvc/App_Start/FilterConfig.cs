using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Collections;
using System.Net.Http;
using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

namespace AcomMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            //filters.Add(new MyValidateAntiForgeryTokenAttribute());
        }
    }

    //public class WebApiValidateAntiForgeryTokenAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(HttpActionContext actionContext)
    //    {
    //        if (actionContext == null)
    //        {
    //            throw new ArgumentNullException("actionContext");
    //        }

    //        if (actionContext.Request.Method.Method != "GET")
    //        {
    //            var headers = actionContext.Request.Headers;
    //            var tokenCookie = headers
    //                .GetCookies()
    //                .Select(c => c[AntiForgeryConfig.CookieName])
    //                .FirstOrDefault();

    //            var tokenHeader = string.Empty;
    //            if (headers.Contains("X-XSRF-Token"))
    //            {
    //                tokenHeader = headers.GetValues("X-XSRF-Token").FirstOrDefault();
    //            }

    //            AntiForgery.Validate(
    //                tokenCookie != null ? tokenCookie : null, tokenHeader);
    //        }

    //        base.OnActionExecuting(actionContext);
    //    }
    //}
}
    //public class AntiForgeryValidate : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
    //    {
    //        string cookieToken = "";
    //        string formToken = "";

    //        IEnumerable tokenHeaders;
    //        if (actionContext.Request.Headers.TryGetValues("RequestVerificationToken", out tokenHeaders))
    //        {
    //            string[] tokens = tokenHeaders.First().Split(':');
    //            if (tokens.Length == 2)
    //            {
    //                cookieToken = tokens[0].Trim();
    //                formToken = tokens[1].Trim();
    //            }
    //        }
    //        System.Web.Helpers.AntiForgery.Validate(cookieToken, formToken);

    //        base.OnActionExecuting(actionContext);
    //    }
    //}
