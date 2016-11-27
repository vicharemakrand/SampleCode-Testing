using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleCode.DomainServices.AutoMapper;
using SampleCode.IDomainServices;
using SampleCode.IOC.Test;
using SampleCode.IOC.Test.UnitTest.TestUtilities;
using SampleCode.ServiceResponse;
using SampleCode.ViewModels;
using SampleCode.Web.Controllers;
using StructureMap;
using System.Web.Mvc;

namespace SampleCode.Web.Test
{
    [TestClass]
    public class UserControllerTest
    {

        private UserController userController;
        IUserService userService;
        [TestInitialize]
        public void Initialize()
        {
            TestBootstrapper.TestServiceStructureMap();
            AutoMapperInit.BuildMap();
            userService = ObjectFactory.GetInstance<IUserService>();
            userController = new UserController(userService);
            MockControllerHelpers.RegisterTestRoutes();
        }


        [TestMethod]
        public void Edit_updates_the_object_and_returns_a_JsonResult_containing_the_redirect_URL()
        {

            // Arrange

            userController.SetMockController("~/User/Edit");

            // Act
            ViewResult result = (ViewResult)userController.Edit(1);
            var model = ((ResponseResult<UserViewModel>)result.Model).ViewModel;
            // Assert

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(1, model.Id);

        }
    }
}
