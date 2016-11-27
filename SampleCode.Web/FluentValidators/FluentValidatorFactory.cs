using FluentValidation;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleCode.Web.DependencyResolution
{
    public class FluentValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            return ObjectFactory.Container.TryGetInstance(validatorType) as IValidator;
        }
    }
}