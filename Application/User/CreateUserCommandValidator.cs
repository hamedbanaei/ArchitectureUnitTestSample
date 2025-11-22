using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.User.Commands;

namespace Application.User
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
          .NotEmpty()
          .MaximumLength(200);

            RuleFor(x => x.Username)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Email)
                .MaximumLength(200);
        }
    }
}
