using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SilverTech.IRepositories.Core
{
    public interface IDataFactory
    {
        IDataContext Get();
    }
}
