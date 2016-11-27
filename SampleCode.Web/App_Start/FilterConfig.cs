using SampleCode.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace SampleCode.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AuthorizeFilter());
            filters.Add(new WhitespaceFilter());
        }
    }
}