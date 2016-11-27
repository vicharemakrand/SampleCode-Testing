using System;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SampleCode.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AuthorizeFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.HttpContext.Request.HttpMethod.ToUpper() == "POST")
            {
                AntiForgery.Validate();
            }
            ////OnAuthorizationHelp(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                //filterContext.Result = new JsonResult
                //{
                //    Data = new
                //    {
                //        message = "sorry, but you were logged out"
                //    },
                //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                //};

                filterContext.HttpContext.Response.StatusCode = 401;
                filterContext.HttpContext.Response.End();
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }

        ////internal void OnAuthorizationHelp(AuthorizationContext filterContext)
        ////{

        ////    if (filterContext.Result is HttpUnauthorizedResult)
        ////    {
        ////        if (filterContext.HttpContext.Request.IsAjaxRequest())
        ////        {
        ////            filterContext.HttpContext.Response.StatusCode = 401;
        ////            filterContext.HttpContext.Response.End();
        ////        }
        ////    }
        ////}
    }
}
