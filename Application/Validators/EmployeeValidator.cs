using Application.Common;
using Domain.Entities;
using FluentValidation;
using static Application.Common.ValidationMessage;

namespace Application.Validators
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
