using Domain.Entities;
using FluentValidation;
using static Application.Common.ValidationMessage;

namespace Application.Validators
{
    internal class AccessPointValidator: AbstractValidator<AccessPoint>
    {
        public AccessPointValidator() 
        {
            RuleFor(e => e.IpAddress)
                .NotNull().WithMessage(x => NotNull(nameof(x.IpAddress)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.IpAddress)))
                .Matches("^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$").WithMessage(x => InvalidProperty(nameof(x.IpAddress)));

            RuleFor(e => e.Name)
                .NotNull().WithMessage(x => NotNull(nameof(x.Name)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.Name)));

            RuleFor(e => e.AccessPointTypeId)
                .GreaterThan(-1).WithMessage(x => NotEmpty(nameof(x.AccessPointTypeId)));
        }
    }
}
