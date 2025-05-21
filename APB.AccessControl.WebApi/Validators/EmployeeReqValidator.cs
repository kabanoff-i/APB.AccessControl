using APB.AccessControl.Shared.Models.Filters;
using APB.AccessControl.Shared.Models.Requests;
using FluentValidation;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.WebApi.Validators
{
    public class CreateEmployeeReqValidator : AbstractValidator<CreateEmployeeReq>
    {
        public CreateEmployeeReqValidator()
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

    public class UpdateEmployeeReqValidator : AbstractValidator<UpdateEmployeeReq>
    {
        public UpdateEmployeeReqValidator()
        {
            RuleFor(e => e.Id)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.Id)));

            RuleFor(e => e.FirstName)
                .NotNull().WithMessage(x => NotNull(nameof(x.FirstName)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.FirstName)));

            RuleFor(e => e.LastName)
                .NotNull().WithMessage(x => NotNull(nameof(x.LastName)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.LastName)));

            RuleFor(e => e.Photo)
                .NotNull().WithMessage(x => NotNull(nameof(x.Photo)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.Photo)));
        }
    }

    public class EmployeeFilterDtoValidator : AbstractValidator<EmployeeFilterDto>
    {
        public EmployeeFilterDtoValidator()
        {
            RuleFor(e => e.FirstName)
                .Must(x => x == null || !string.IsNullOrEmpty(x))
                .WithMessage(x => InvalidProperty(nameof(x.FirstName)));

            RuleFor(e => e.LastName)
                .Must(x => x == null || !string.IsNullOrEmpty(x))
                .WithMessage(x => InvalidProperty(nameof(x.LastName)));

            RuleFor(e => e.PatronymicName)
                .Must(x => x == null || !string.IsNullOrEmpty(x))
                .WithMessage(x => InvalidProperty(nameof(x.PatronymicName)));

            RuleFor(e => e.Department)
                .Must(x => x == null || !string.IsNullOrEmpty(x))
                .WithMessage(x => InvalidProperty(nameof(x.Department)));

            RuleFor(e => e.Position)
                .Must(x => x == null || !string.IsNullOrEmpty(x))
                .WithMessage(x => InvalidProperty(nameof(x.Position)));

            RuleFor(e => e.PassportNumber)
                .Must(x => x == null || !string.IsNullOrEmpty(x))
                .WithMessage(x => InvalidProperty(nameof(x.PassportNumber)))
                .Matches(@"^\d{7}$").When(x => !string.IsNullOrEmpty(x.PassportNumber))
                .WithMessage(x => InvalidProperty(nameof(x.PassportNumber)));
        }
    }
}
