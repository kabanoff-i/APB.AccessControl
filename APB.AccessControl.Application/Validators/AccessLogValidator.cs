using APB.AccessControl.Application.Common;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Primitives;
using FluentValidation;
using System;
using static APB.AccessControl.Application.Common.ValidationMessage;

namespace APB.AccessControl.APB.AccessControl.Application.Validators
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
