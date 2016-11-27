using SampleCode.IRepositories;
using SampleCode.ServiceResponse;
using SampleCode.ViewModels;

namespace SampleCode.DomainServices
{
    public interface IUserService1
    {
        IUserRepository UserRepository { get; set; }

        ResponseResult<UserViewModel> GetUserList(string userName);
    }
}