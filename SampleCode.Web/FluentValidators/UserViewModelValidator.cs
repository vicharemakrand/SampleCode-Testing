using FluentValidation;
using SampleCode.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleCode.Web.FluentValidators
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty().WithMessage(AppMessages.Required_FirstName_Message);
            RuleFor(user => user.LastName).NotEmpty().WithMessage(AppMessages.Required_LastName_Message);
            RuleFor(user => user.UserName).NotEmpty().WithMessage(AppMessages.Required_UserName_Message);
        }
    }
}