using SampleCode.IRepositories.Core;
using SampleCode.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.Repositories.Core
{
    public abstract class BaseRepository<Model> : IBaseRepository<Model> where Model : BaseModel
    {
        protected DataContext dataContext = null;

        protected DataFactory DataFactory
        {
            get;
            private set;
        }

        protected DataContext DataContext
        {
            get { return dataContext ?? (dataContext = DataFactory.Get()); }
        }

        public BaseRepository(DataFactory dataFactory)
        {
            this.DataFactory = dataFactory;
        }

        public BaseRepository(IUnitOfWork unitOfWork)
        {

        }

        protected DbSet<Model> DbSet
        {
            get
            {
                return DataContext.Set<Model>();
            }
        }

        #region Operational Methods

        public virtual IEnumerable<Model> GetAll()
        {
            return DbSet.AsEnumerable();
        }

        public virtual Model GetById(long id)
        {
            return DbSet.Where(o=>o.Id == id).FirstOrDefault();
        }

        public virtual Model Get(Expression<Func<Model, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual IEnumerable<Model> GetMany(Expression<Func<Model, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual bool Contains(Expression<Func<Model, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public virtual Model Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }


        public virtual Model Add(Model model)
        {
            var newEntry = DbSet.Add(model);
            DataContext.SaveChanges();

            return newEntry;
        }

        public virtual Model Update(Model model)
        {
            var existingModel = DataContext.Entry(model);
            DbSet.Attach(model);
            existingModel.State = EntityState.Modified;

            DataContext.SaveChanges();
            return model;
        }

        public virtual int Delete(Model model)
        {
            DbSet.Remove(model);
            return DataContext.SaveChanges();
        }

        public virtual int Delete(Expression<Func<Model, bool>> predicate)
        {
            var objects = GetMany(predicate);

            foreach (var obj in objects)
                DbSet.Remove(obj);
            return DataContext.SaveChanges();
        }

        public virtual int Delete(long id)
        {
            var model = GetById(id);
            DbSet.Remove(model);
            return DataContext.SaveChanges();
        }

        public virtual int Count
        {
            get { return DbSet.Count(); }
        }

        #endregion

        public void Dispose()
        {
            if (this.dataContext != null)
                this.dataContext.Dispose();
        }
    }
}
