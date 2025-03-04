using APB.AccessControl.Domain.Entities;
using FluentValidation;
using System.Reflection;
using static APB.AccessControl.Application.Common.ValidationMessage;

namespace APB.AccessControl.Application.Validators
{
    internal class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(e => e.Hash)
                .NotNull().WithMessage(x => NotNull(nameof(x.Hash)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.Hash)))
                .Matches("^[a-fA-F0-9]{40}$").WithMessage(x => InvalidProperty(nameof(x.Hash)));

            RuleFor(e => e.EmployeeId)
                .GreaterThan(-1).WithMessage(x => InvalidProperty(nameof(x.EmployeeId)));
        }
    }
}
