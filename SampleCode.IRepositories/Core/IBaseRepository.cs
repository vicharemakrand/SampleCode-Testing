using SampleCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.IRepositories.Core
{
    public interface IBaseRepository<Model> where Model : BaseModel
    {
        IEnumerable<Model> GetAll();
        Model GetById(long id);
        Model Get(Expression<Func<Model, bool>> predicate);
        IEnumerable<Model> GetMany(Expression<Func<Model, bool>> predicate);
        bool Contains(Expression<Func<Model, bool>> predicate);
        Model Find(params object[] keys);
        Model Add(Model model);
        Model Update(Model model);
        int Delete(Model model);
        int Delete(Expression<Func<Model, bool>> predicate);
        int Delete(long id);
        int Count { get; }
    }
}
