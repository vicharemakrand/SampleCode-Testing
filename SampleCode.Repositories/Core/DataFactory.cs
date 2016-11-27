using SampleCode.IRepositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.Repositories.Core
{
    public class DataFactory : IDisposable
{
        private DataContext _sampleContext;

        public DataContext Get()
    {
        return _sampleContext ?? (_sampleContext = new DataContext());
    }

    public void Dispose()
    {
        //if (null != _sampleContext)  _sampleContext.Dispose();
    }
}
}
