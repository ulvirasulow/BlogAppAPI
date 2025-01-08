using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BlogApp.Business.DTOs.User
{
    public record LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .WithMessage("Username ve ya Password yanlisdir!");
        }
    }
}
