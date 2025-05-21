using FluentValidation;
using APB.AccessControl.Domain.Entities;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.Application.Validators
{
    public class AccessGroupValidator: AbstractValidator<AccessGroup>
    {
        public AccessGroupValidator()
        {
            RuleFor(e => e.Name)
                .NotNull().WithMessage(x => NotNull(nameof(x.Name)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.Name)));

        }
    }
}
