using Moq;
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
    public static class MockRepositoryGenerator<Model> where Model : BaseModel
    {

        private static List<Model> DummyTable
        {
            get
            {
                return MockEntities.GetData<Model>();
            }
        }

        public static T RepositoryMock<T>() where T:class,IBaseRepository<Model>
        {
            Mock<T> repository = new Mock<T>(MockBehavior.Strict);
            
            repository.Setup(o => o.GetAll()).Returns(DummyTable.ToList());
            repository.Setup(o => o.GetMany(It.IsAny<Expression<Func<Model, bool>>>())).Returns((Expression<Func<Model, bool>> i) => DummyTable.Where(i.Compile()).ToList());
            repository.Setup(o => o.Get(It.IsAny<Expression<Func<Model, bool>>>())).Returns((Expression<Func<Model, bool>> i) => DummyTable.Where(i.Compile()).FirstOrDefault());
            repository.Setup(o => o.GetById(It.IsAny<long>())).Returns<long>(id => DummyTable.Where(o=>o.Id==id).FirstOrDefault());
            repository.Setup(o => o.Add(It.IsAny<Model>())).Returns<Model>(item =>
                                                                                {
                                                                                    DummyTable.Add(item); 
                                                                                    return item;
                                                                                });
            repository.Setup(o => o.Update(It.IsAny<Model>())).Returns<Model>(item =>
            {
                var exisitngItem = DummyTable.Find(o => o.Id == item.Id);
                DummyTable.Remove(exisitngItem);
                DummyTable.Add(item); 
                return item;
            });
            repository.Setup(o => o.Delete(It.IsAny<Model>())).Callback<Model>(item => DummyTable.Remove(item));
            return repository.Object;
        }
    }
}
