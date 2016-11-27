using SampleCode.IOC.Test.UnitTest.TestUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace SampleCode.Web.Test
{
     public class MockControllerHelpers
    {
         public static void RegisterTestRoutes()
        {
            RouteTable.Routes.Clear();
            //var areaRegistration = new DemoAreaRegistration();
            //var areaRegistrationContext = new AreaRegistrationContext(
            //    areaRegistration.AreaName, RouteTable.Routes);
            //areaRegistration.RegisterArea(areaRegistrationContext);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }


         
    }
}
