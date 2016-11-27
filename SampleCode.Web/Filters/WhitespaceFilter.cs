using SampleCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SampleCode.Web.Filters
{
    public class WhitespaceFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
            if (response.ContentType != "text/html" || response.Filter == null) return;

            response.Filter = new WhitespaceStream(response.Filter);
        }

    }
}
