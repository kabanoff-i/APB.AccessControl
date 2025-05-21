using APB.AccessControl.Shared.Models.Requests;
using FluentValidation;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.WebApi.Validators
{
    public class CheckAccessReqValidator : AbstractValidator<CheckAccessReq>
    {
        public CheckAccessReqValidator()
        {
            RuleFor(e => e.CardHash)
                .NotNull().WithMessage(x => NotNull(nameof(x.CardHash)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.CardHash)))
                .Matches("^[a-fA-F0-9]{40}$").WithMessage(x => InvalidProperty(nameof(x.CardHash)));

            RuleFor(e => e.AcсessPointId)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.AcсessPointId)));

            RuleFor(e => e.DateAccess)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.DateAccess)));
        }
    }
} 