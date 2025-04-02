using FluentValidation;
using APB.AccessControl.Domain.Entities;
using static APB.AccessControl.Application.Common.ValidationMessage;

namespace APB.AccessControl.Application.Validators
{
    public class TriggerValidator: AbstractValidator<Trigger>
    {
        public TriggerValidator() 
        {
            RuleFor(x => x.AccessPointId)
                .GreaterThan(-1).WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(x => x.ActionType)
                .IsInEnum().WithMessage(x => InvalidProperty(nameof(x.ActionType)));

            RuleFor(x => x.AccessResult)
                .IsInEnum().WithMessage(x => InvalidProperty(nameof(x.ActionType)));

            RuleFor(x => x.ActionValue)
                .NotNull().WithMessage(x => NotNull(nameof(x.ActionValue)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.ActionValue)));
        }
    }
}
