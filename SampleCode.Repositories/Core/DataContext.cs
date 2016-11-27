using SampleCode.IRepositories.Core;
using SampleCode.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.Repositories.Core
{
    public class DataContext : DbContext, IDataContext  
    {
        public DbSet<UserModel> Users { get; set; }

    public DataContext(string contextName) :base(contextName)
    {
    }

    public DataContext()
        : base("LocalConnection")
    {
    }

    public virtual void Commit() 
    {
        base.SaveChanges();
    }
    }
}
