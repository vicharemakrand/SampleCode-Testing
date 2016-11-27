using System;
using SampleCode.ViewModels;
using SampleCode.ServiceResponse;
using SampleCode.Models;
using SampleCode.IRepositories.Core;

namespace SampleCode.IDomainServices.Core
{
    public interface IBaseService<T,VM>  where T : BaseModel  where VM : BaseViewModel
    {
        ResponseResults<VM> GetAll();
        ResponseResult<VM> GetById(long id);
        ResponseResult<VM> Save(VM viewModel);
        IBaseRepository<T> BaseRepository { get; set; }
        IUnitOfWork UnitOfWork { get; set; }
    }
}
