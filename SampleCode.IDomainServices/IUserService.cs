using System;
using SampleCode.ServiceResponse;
using SampleCode.IDomainServices.Core;
using SampleCode.Models;
using SampleCode.ViewModels;
using SampleCode.IRepositories;

namespace SampleCode.IDomainServices
{
    public interface IUserService : IBaseService<UserModel, UserViewModel>
    {
        ResponseResult<UserViewModel> GetUserList(string userName);
        IUserRepository UserRepository { get; set; }
    }
}
