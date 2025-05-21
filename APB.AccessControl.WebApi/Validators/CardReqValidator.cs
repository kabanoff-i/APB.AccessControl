using APB.AccessControl.Shared.Models.Requests;
using FluentValidation;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.WebApi.Validators
{
    public class CreateCardReqValidator : AbstractValidator<CreateCardReq>
    {
        public CreateCardReqValidator()
        {
            RuleFor(e => e.Hash)
                .NotNull().WithMessage(x => NotNull(nameof(x.Hash)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.Hash)))
                .Matches("^[a-fA-F0-9]{40}$").WithMessage(x => InvalidProperty(nameof(x.Hash)));

            RuleFor(e => e.EmployeeId)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.EmployeeId)));
        }
    }

    public class UpdateCardReqValidator : AbstractValidator<UpdateCardReq>
    {
        public UpdateCardReqValidator()
        {
            RuleFor(e => e.Id)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.Id)));
        }
    }
} 