using FluentValidation;
using Domain.Entities;
using static Application.Common.ValidationMessage;
using System;


namespace Application.Validators
{
    public class AccessTriggerLogValidator: AbstractValidator<AccessTriggerLog>
    {
        public AccessTriggerLogValidator()
        {
            RuleFor(x => x.AccessLogId)
                .Must(x => x != Guid.Empty)
                .WithMessage(x => NotEmpty(nameof(x.AccessLogId)));

            RuleFor(x => x.AccessLogId.ToString())
                .Matches(@"^[{]?[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}[}]?$")
                .WithMessage(x => InvalidProperty(nameof(x.AccessLogId)));

            RuleFor(x => x.TriggerId)
                .GreaterThan(-1).WithMessage(x => InvalidProperty(nameof(x.TriggerId)));

            RuleFor(x => x.ExecuteAt)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.ExecuteAt)));
        }
    }
}
