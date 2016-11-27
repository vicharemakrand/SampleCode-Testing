using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;
using SampleCode.IRepositories;
using SampleCode.Models;
using SampleCode.IOC.Test;

namespace SampleCode.Repositories.Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        private IUserRepository repository;
        [TestInitialize]
        public void Initialize()
        {
            TestBootstrapper.TestRepositoryStructureMap();
            repository = ObjectFactory.GetInstance<IUserRepository>();

        }

        [TestMethod]
        public void Add_AddNewUser_returnsSaveUser()
        {
            var model = repository.Add(new UserModel() { Id =11 , FirstName ="Mak" , LastName ="Vichare"});
            Assert.AreEqual("Vichare", model.LastName); 
        }

        [TestMethod]
        public void Update_UpdateExistingUser_returnsSaveUser()
        {
            var oldModel = repository.GetById(5);
            oldModel.FirstName = "Makrand";
            var model = repository.Update(oldModel);
            Assert.AreEqual(oldModel.FirstName, model.FirstName);
        }
    }
}
