using FluentValidation;
using Domain.Entities;
using static Application.Common.ValidationMessage;

namespace Application.Validators
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
