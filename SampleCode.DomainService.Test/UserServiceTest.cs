using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleCode.IOC.Test;
using StructureMap;
using SampleCode.IDomainServices;
using SampleCode.ViewModels;
using SampleCode.DomainServices.AutoMapper;
using SampleCode.DomainServices;
using SampleCode.IRepositories;
using SampleCode.IRepositories.Core;

namespace SampleCode.DomainService.Test
{
    [TestClass]
    public class UserServiceTest
    {
        private IUserService domainService;

        /// <summary>
        ///Initialize() is called once during test execution before
        ///test methods in this test class are executed.
        ///</summary>
        [TestInitialize]
        public void Initialize()
        {
            TestBootstrapper.TestServiceStructureMap();
            AutoMapperInit.BuildMap();
            domainService = ObjectFactory.GetInstance<IUserService>();
            domainService.UserRepository = ObjectFactory.GetInstance<IUserRepository>();
            domainService.UnitOfWork = ObjectFactory.GetInstance<IUnitOfWork>();
        }

        /// <summary>
        ///Cleanup() is called once during test execution after
        ///test methods in this class have executed unless
        ///this test class' Initialize() method throws an exception.
        ///</summary>
        [TestCleanup()]
        public void Cleanup()
        {

            //  TODO: Add test cleanup code
        }

        [TestMethod]
        public void Save_AddNewUser_returnsSaveUser()
        {
            var response = domainService.Save(new UserViewModel() { Id = 0, FirstName = "Mak11", LastName = "Vichare11" });
            Assert.AreEqual("Vichare11", response.ViewModel.LastName);
        }

        [TestMethod]
        public void Save_UpdateExistingUser_returnsSaveUser()
        {
            var response = domainService.GetById(5);
            response.ViewModel.FirstName = "Makrand";
            var newResponse = domainService.Save(response.ViewModel);
            Assert.AreEqual(response.ViewModel.FirstName, newResponse.ViewModel.FirstName);
        }
    }
}
