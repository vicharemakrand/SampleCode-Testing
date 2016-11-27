using Moq;
using SampleCode.IDomainServices;
using SampleCode.IRepositories.Core;
using SampleCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.IOC.Test
{
    public static class MockGenerator 
    {

        public static IUnitOfWork UnitOfWorkMock()
        {
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWork.Setup(o => o.Commit()).Verifiable();
            return unitOfWork.Object;
        }

        public static IDataContext DataContextMock()
        {
            Mock<IDataContext> dataContext = new Mock<IDataContext>(MockBehavior.Strict);
            return dataContext.Object;
        }
    }
}
