using SampleCode.IRepositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.Repositories.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataFactory dataFactory;
        private DataContext dataContext;

        public DataContext DataContext
        {
            get
            {
                return this.dataContext ?? (dataContext = dataFactory.Get());
            }
        }

        public UnitOfWork(DataFactory dataFactory)
        {
            this.dataFactory = dataFactory;
        }

        public UnitOfWork()
        {
            this.dataFactory = new DataFactory();
        }

        public void Commit()
        {
            this.DataContext.Commit();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
