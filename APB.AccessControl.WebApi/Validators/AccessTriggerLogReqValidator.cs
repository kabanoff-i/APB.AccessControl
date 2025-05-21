using APB.AccessControl.Shared.Models.Filters;
using APB.AccessControl.Shared.Models.Requests;
using FluentValidation;
using System;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.WebApi.Validators
{
    public class CreateAccessTriggerLogReqValidator : AbstractValidator<CreateAccessTriggerLogReq>
    {
        public CreateAccessTriggerLogReqValidator()
        {
            RuleFor(x => x.AccessLogId)
                .Must(x => x != Guid.Empty)
                .WithMessage(x => NotEmpty(nameof(x.AccessLogId)));

            RuleFor(x => x.AccessLogId.ToString())
                .Matches(@"^[{]?[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}[}]?$")
                .WithMessage(x => InvalidProperty(nameof(x.AccessLogId)));

            RuleFor(x => x.TriggerId)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.TriggerId)));

            RuleFor(x => x.ExecutedAt)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.ExecutedAt)))
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage(x => InvalidProperty(nameof(x.ExecutedAt)));

            When(x => !x.ExecutionResult, () => {
                RuleFor(x => x.ErrorMessage)
                    .NotNull().WithMessage(x => NotNull(nameof(x.ErrorMessage)))
                    .NotEmpty().WithMessage(x => NotEmpty(nameof(x.ErrorMessage)));
            });
        }
    }

    public class AccessTriggerLogFilterDtoValidator : AbstractValidator<AccessTriggerLogFilterDto>
    {
        public AccessTriggerLogFilterDtoValidator()
        {
            RuleFor(e => e.AccessLogId)
                .Must(x => x == null || x != Guid.Empty).When(x => x.AccessLogId.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.AccessLogId)));

            RuleFor(e => e.TriggerId)
                .GreaterThan(0).When(x => x.TriggerId.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.TriggerId)));

            RuleFor(e => e.ExecuteAtStart)
                .LessThanOrEqualTo(x => x.ExecuteAtEnd).When(x => x.ExecuteAtEnd.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.ExecuteAtStart)));

            RuleFor(e => e.ExecuteAtEnd)
                .GreaterThanOrEqualTo(x => x.ExecuteAtStart).When(x => x.ExecuteAtStart.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.ExecuteAtEnd)));
        }
    }
} 