using SampleCode.IRepositories.Core;
using SampleCode.Models;
using System;
namespace SampleCode.IRepositories
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        UserModel GetUserByName(string userName);
    }
}
