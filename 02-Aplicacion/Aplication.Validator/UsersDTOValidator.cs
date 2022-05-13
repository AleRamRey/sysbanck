using System;
using FluentValidation;
using Application.DTO;

namespace Application.Validator
{
    public class UsersDTOValidator : AbstractValidator<UsersDto>
    {
        public UsersDTOValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }

    }
}
