using SampleCode.IDomainServices;
using SampleCode.Models;
using SampleCode.ViewModels;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleCode.Web.Controllers
{
    public class UserController : BaseAuditableController<UserModel,UserViewModel>
    {
        private readonly IUserService userService;

        public UserController(IUserService userService):base(userService)
        {
            this.userService = userService;
        }
      }
}
