using APB.AccessControl.Shared.Models.Filters;
using APB.AccessControl.Shared.Models.Requests;
using FluentValidation;
using System;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.WebApi.Validators
{
    public class CreateAccessLogReqValidator : AbstractValidator<CreateAccessLogReq>
    {
        public CreateAccessLogReqValidator()
        {
            RuleFor(e => e.CardId)
                .GreaterThan(0).When(x => x.CardId.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.CardId)));
                
            RuleFor(e => e.CardHash)
                .NotNull().WithMessage(x => NotNull(nameof(x.CardHash)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.CardHash)))
                .Matches("^[a-fA-F0-9]{40}$").WithMessage(x => InvalidProperty(nameof(x.CardHash)));

            RuleFor(e => e.EmployeeId)
                .GreaterThan(0).When(x => x.EmployeeId.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.EmployeeId)));

            RuleFor(e => e.AccessPointId)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(e => e.DateAccess)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.DateAccess)))
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage(x => InvalidProperty(nameof(x.DateAccess)));

            RuleFor(e => e.AccessResult)
                .InclusiveBetween(0, 3).WithMessage(x => InvalidProperty(nameof(x.AccessResult)));
        }
    }

    public class AccessLogFilterDtoValidator : AbstractValidator<AccessLogFilterDto>
    {
        public AccessLogFilterDtoValidator()
        {
            RuleFor(e => e.AccessTimeStart)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.AccessTimeStart)))
                .LessThanOrEqualTo(x => x.AccessTimeEnd).When(x => x.AccessTimeEnd.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.AccessTimeStart)));

            RuleFor(e => e.AccessTimeEnd)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.AccessTimeEnd)))
                .GreaterThanOrEqualTo(x => x.AccessTimeStart).When(x => x.AccessTimeStart.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.AccessTimeEnd)))
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage(x => InvalidProperty(nameof(x.AccessTimeEnd)));

            RuleFor(e => e.EmployeeId)
                .GreaterThan(0).When(x => x.EmployeeId.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.EmployeeId)));

            RuleFor(e => e.AccessPointId)
                .GreaterThan(0).When(x => x.AccessPointId.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(e => e.AccessResult)
                .InclusiveBetween(0, 3).When(x => x.AccessResult.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.AccessResult)));
        }
    }
} 