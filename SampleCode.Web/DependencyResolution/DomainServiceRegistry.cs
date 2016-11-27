using SampleCode.DomainServices;
using SampleCode.IDomainServices;
using SampleCode.IDomainServices.Core;
using SampleCode.IRepositories;
using SampleCode.IRepositories.Core;
using SampleCode.Repositories;
using StructureMap.Graph;

namespace SampleCode.Web.DependencyResolution
{
    public class DomainServiceRegistry : StructureMap.Configuration.DSL.Registry
    {
        public DomainServiceRegistry()
        {
            Scan(cfg =>
            {
                cfg.WithDefaultConventions();

                cfg.Assembly("SampleCode.DomainServices");
                cfg.Assembly("SampleCode.IDomainServices");
                cfg.AddAllTypesOf(typeof(IBaseService<,>));

                cfg.Assembly("SampleCode.Repositories");
                cfg.Assembly("SampleCode.IRepositories");

                cfg.AddAllTypesOf(typeof(IBaseRepository<>));
                cfg.AddAllTypesOf<IUnitOfWork>();
                cfg.AddAllTypesOf(typeof(IDataContext));

            });
         }
    }
}