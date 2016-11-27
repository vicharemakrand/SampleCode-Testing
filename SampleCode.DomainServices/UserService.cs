using SampleCode.DomainServices.Core;
using SampleCode.IRepositories;
using SampleCode.IRepositories.Core;
using SampleCode.Models;
using SampleCode.ServiceResponse;
using SampleCode.ViewModels;
using System;
using SampleCode.IDomainServices;
using StructureMap;
using StructureMap.Attributes;

namespace SampleCode.DomainServices
{
    public class UserService : BaseService<UserModel, UserViewModel>, IUserService
    {
        private IUserRepository userRepository;
       // private readonly IUnitOfWork unitOfWork;

       // [SetterProperty]
        public IUserRepository UserRepository {
            get
            {
                return userRepository;
            }
            set
            {
                userRepository = value;
                base.BaseRepository = value;
            }
        }

        public UserService() :base()
        {
            //ObjectFactory.BuildUp(this);  /// this can be used only instance created using new keyword
            /// but then we can not mock it
            /// 
            //userRepository = UserRepository;
            //unitOfWork = UnitOfWork;
        }

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork) : base(unitOfWork, userRepository)
        {
            this.userRepository = userRepository;
            //base.UnitOfWork = unitOfWork;
        }

        public ResponseResult<UserViewModel> GetUserList(string userName)
        {
            var response = new ResponseResult<UserViewModel>() { IsSucceed = true, Message = "succeed" };
            try
            {
                var userModel = userRepository.GetUserByName(userName);
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

    }
}
