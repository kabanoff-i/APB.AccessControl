using APB.AccessControl.Shared.Models.Requests;
using FluentValidation;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.WebApi.Validators
{
    public class CreateGroupReqValidator : AbstractValidator<CreateGroupReq>
    {
        public CreateGroupReqValidator()
        {
            RuleFor(e => e.Name)
                .NotNull().WithMessage(x => NotNull(nameof(x.Name)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.Name)));
        }
    }

    public class UpdateGroupReqValidator : AbstractValidator<UpdateGroupReq>
    {
        public UpdateGroupReqValidator()
        {
            RuleFor(e => e.Id)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.Id)));

            RuleFor(e => e.Name)
                .NotNull().WithMessage(x => NotNull(nameof(x.Name)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.Name)));
        }
    }
} 