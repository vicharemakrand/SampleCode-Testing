using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.DomainServices.AutoMapper
{
    public class AutoMapperInit
    {
        public static void BuildMap()
        {
            Mapper.Initialize(o => o.AddProfile(new ModelAutoMapperProfiler()));
        }
    }
}
