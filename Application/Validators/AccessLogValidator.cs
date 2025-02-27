using Application.Common;
using Domain.Entities;
using Domain.Primitives;
using FluentValidation;
using static Application.Common.ValidationMessage;

namespace Application.Validators
{
    public class AccesslogValidator : AbstractValidator<AccessLog>
    {
        public AccesslogValidator()
        {
            RuleFor(e => e.CardId)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.CardId)))
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.CardId)));

            RuleFor(e => e.EmployeeId)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.EmployeeId)))
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.EmployeeId)));

            RuleFor(e => e.AccessPointId)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.AccessPointId)))
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(e => e.AccessTime)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.AccessTime)));

            RuleFor(e => e.CardId)
                .IsInEnum().WithMessage(x => NotEmpty(nameof(x.AccessResult)));
        }
    }
}
