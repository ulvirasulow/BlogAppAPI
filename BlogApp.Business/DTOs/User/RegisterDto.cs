using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;

namespace BlogApp.Business.DTOs.User
{
    public record RegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(40);
            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(40);
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .Must(x =>
                {
                    Regex regex = new Regex("^[a-z0-9]+(?!.*(?:\\+{2,}|\\-{2,}|\\.{2,}))(?:[\\.+\\-]{0,1}[a-z0-9])*@gmail\\.com$");
                    var math = regex.Match(x);
                    return math.Success;
                });
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4);
            RuleFor(x => x)
                .Must(x => x.Password == x.ConfirmPassword);
        }
    }
}
