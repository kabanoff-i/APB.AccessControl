using APB.AccessControl.Application.Common;
using APB.AccessControl.Domain.Entities;
using FluentValidation;
using static APB.AccessControl.Application.Common.ValidationMessage;

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
        }
    }
}
