using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SampleCode.Web.DependencyResolution
{

    public class IOCControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller = (controllerType != null) ? ObjectFactory.GetInstance(controllerType) as Controller : null;
            return controller;
        }

        //protected override IController GetControllerInstance(Type controllerType)
        //{
        //    IController controller = (controllerType != null) ? ObjectFactory.GetInstance(controllerType) as Controller : null;
        //    return controller;
        //}
    }
}