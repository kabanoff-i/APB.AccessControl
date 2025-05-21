using APB.AccessControl.Shared.Models.Requests;
using FluentValidation;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.WebApi.Validators
{
    public class HeartbeatReqValidator : AbstractValidator<HeartbeatReq>
    {
        public HeartbeatReqValidator()
        {
            RuleFor(x => x.AccessPointId)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.AccessPointId)))
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(x => x.TimeStamp)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.TimeStamp)));
        }
    }
} 