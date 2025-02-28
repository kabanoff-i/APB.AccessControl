using Application.Common;
using Domain.Entities;
using Domain.Primitives;
using FluentValidation;
using System;
using static Application.Common.ValidationMessage;

namespace Application.Validators
{
    public class AccesslogValidator : AbstractValidator<AccessLog>
    {
        public AccesslogValidator()
        {
            RuleFor(e => e.CardId)
                .GreaterThan(-1).WithMessage(x => InvalidProperty(nameof(x.CardId)));

            RuleFor(e => e.EmployeeId)
                .GreaterThan(-1).WithMessage(x => InvalidProperty(nameof(x.EmployeeId)));

            RuleFor(e => e.AccessPointId)
                .GreaterThan(-1).WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(e => e.AccessTime)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.AccessTime)))
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage(x => InvalidProperty(nameof(x.AccessTime)));

            RuleFor(e => e.AccessResult)
                .IsInEnum().WithMessage(x => NotEmpty(nameof(x.AccessResult)));
        }
    }
}
