using Moq;
using SampleCode.DomainServices.Core;
using SampleCode.IDomainServices.Core;
using SampleCode.Models;
using SampleCode.ViewModels;

namespace SampleCode.IOC.Test
{
    public static class MockServiceGenerator<Model, ViewModel> where Model : BaseModel where ViewModel: BaseViewModel
    {
        // this creates completely new mock object and does not use real implementation at all
        // overlayer mocked objects can not be used automatically.
        //public static T ServiceMock1<T>() where T : class, IBaseService<Model, ViewModel> 
        //{
        //    Mock<T> service = new Mock<T>(MockBehavior.Strict);
        //    service.CallBase = true;
        //    service.Setup(o => o.GetById(It.IsAny<long>())).Returns<long>(id => null);

        //    return service.Object;
        //}

        public static T ServiceMock<T>() where T : BaseService<Model, ViewModel>
        {
            Mock<T> service = new Mock<T>(MockBehavior.Loose);
            service.CallBase = true;
            service.Setup(o => o.GetById(It.IsAny<long>())).Returns<long>(id => null);

            return service.Object;
        }
    }
}
