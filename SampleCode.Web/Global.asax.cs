using FluentValidation.Mvc;
using SampleCode.DomainServices.AutoMapper;
using SampleCode.Web.DependencyResolution;
using StructureMap;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SampleCode.Web
{
     public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            AutoMapperInit.BuildMap();
            ControllerBuilder.Current.SetControllerFactory(new IOCControllerFactory());

            // Configure FluentValidation to use StructureMap
            var factory = new FluentValidatorFactory();

            // Tell MVC to use FluentValidation for validation
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(factory));
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        }
    }
}