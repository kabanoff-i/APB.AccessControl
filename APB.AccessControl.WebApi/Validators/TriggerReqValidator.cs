using APB.AccessControl.Shared.Models.Requests;
using FluentValidation;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.WebApi.Validators
{
    public class CreateTriggerReqValidator : AbstractValidator<CreateTriggerReq>
    {
        public CreateTriggerReqValidator()
        {
            RuleFor(x => x.AccessPointId)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(x => x.ActionType)
                .InclusiveBetween(0, 3).WithMessage(x => InvalidProperty(nameof(x.ActionType)));

            RuleFor(x => x.AccessResult)
                .InclusiveBetween(0, 3).WithMessage(x => InvalidProperty(nameof(x.AccessResult)));

            RuleFor(x => x.ActionValue)
                .NotNull().WithMessage(x => NotNull(nameof(x.ActionValue)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.ActionValue)));
        }
    }

    public class UpdateTriggerReqValidator : AbstractValidator<UpdateTriggerReq>
    {
        public UpdateTriggerReqValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.Id)));

            RuleFor(x => x.AccessPointId)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(x => x.ActionType)
                .InclusiveBetween(0, 3).WithMessage(x => InvalidProperty(nameof(x.ActionType)));

            RuleFor(x => x.AccessResult)
                .InclusiveBetween(0, 3).WithMessage(x => InvalidProperty(nameof(x.AccessResult)));

            RuleFor(x => x.ActionValue)
                .NotNull().WithMessage(x => NotNull(nameof(x.ActionValue)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.ActionValue)));
        }
    }
} 