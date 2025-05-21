using APB.AccessControl.Application.Common;
using APB.AccessControl.Domain.Entities;
using FluentValidation;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.Application.Validators
{
    public class EmployeeValidator: AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName)
                .NotNull().WithMessage(x => NotNull(nameof(x.FirstName)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.FirstName)));

            RuleFor(e => e.LastName)
                .NotNull().WithMessage(x => NotNull(nameof(x.LastName)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.LastName)));

            RuleFor(e => e.PassportNumber)
                .NotNull().WithMessage(x => NotNull(nameof(x.PassportNumber)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.PassportNumber)))
                .Matches(@"^\d{7}$").WithMessage(x => InvalidProperty(nameof(x.PassportNumber)));

            RuleFor(e => e.Photo)
                .NotNull().WithMessage(x => NotNull(nameof(x.Photo)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.Photo)));
        }
    }
}
