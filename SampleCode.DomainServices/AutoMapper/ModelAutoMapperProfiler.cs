using AutoMapper;
using SampleCode.Models;
using SampleCode.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.DomainServices.AutoMapper
{
    public class ModelAutoMapperProfiler : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            Mapper.CreateMap<BaseModel, BaseViewModel>().ReverseMap();
            Mapper.CreateMap<AuditableModel, AuditableViewModel>().ReverseMap();
            Mapper.CreateMap<UserModel, UserViewModel>().ReverseMap();
        }
    }
}
