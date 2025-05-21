using APB.AccessControl.Application.Common;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Domain.Primitives;
using FluentValidation;
using System;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.APB.AccessControl.Application.Validators
{
    public class AccesslogValidator : AbstractValidator<AccessLog>
    {
        public AccesslogValidator()
        {
            RuleFor(e => e.CardId)
                .GreaterThan(-1).When(x => x.CardId != null)
                .WithMessage(x => InvalidProperty(nameof(x.CardId)));
                
            RuleFor(e => e.CardHash)
                .NotNull().WithMessage(x => NotNull(nameof(x.CardHash)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.CardHash)))
                .Matches("^[a-fA-F0-9]{40}$").WithMessage(x => InvalidProperty(nameof(x.CardHash)));

            RuleFor(e => e.EmployeeId)
                .GreaterThan(-1).WithMessage(x => InvalidProperty(nameof(x.EmployeeId)));

            RuleFor(e => e.AccessPointId)
                .GreaterThan(-1).WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(e => e.DateAccess)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.DateAccess)))
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage(x => InvalidProperty(nameof(x.DateAccess)));

            RuleFor(e => e.AccessResult)
                .IsInEnum().WithMessage(x => NotEmpty(nameof(x.AccessResult)));
        }
    }
}
