using FluentValidation;
using SampleCode.Web.FluentValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleCode.Web.DependencyResolution
{
    public class FluentValidatorRegistry : StructureMap.Configuration.DSL.Registry
    {
        public FluentValidatorRegistry()
        {
            FluentValidation.AssemblyScanner.FindValidatorsInAssemblyContaining<UserViewModelValidator>()
            .ForEach(result =>
            {
                For(result.InterfaceType)
                    .Singleton()
                    .Use(result.ValidatorType);
            });
        }
    }
}