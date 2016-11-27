using Moq;
using SampleCode.DomainServices;
using SampleCode.IDomainServices;
using SampleCode.IDomainServices.Core;
using SampleCode.IRepositories;
using SampleCode.IRepositories.Core;
using SampleCode.Models;
using SampleCode.ViewModels;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.IOC.Test.DependencyResolution
{
    class StructureMapRepositoryTestRegistry : Registry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyConfigurationRegistry"/> class.
        /// </summary>
        public StructureMapRepositoryTestRegistry()
        {
            MockEntities.LoadData();

            For<IUserRepository>().Use(MockRepositoryGenerator<UserModel>.RepositoryMock<IUserRepository>());
            For<IUnitOfWork>().Use(MockGenerator.UnitOfWorkMock());
            For<IDataContext>().Use(MockGenerator.DataContextMock());

        }
    }
}
