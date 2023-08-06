using System;
using FluentValidation;
using Pacagroup.Ecommerce.Application.DTO;

namespace Pacagroup.Ecommerce.Application.Validator
{
    public class UserDtoValidator : AbstractValidator<UsersDTO>
    {
        public UserDtoValidator() 
        { 
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}
