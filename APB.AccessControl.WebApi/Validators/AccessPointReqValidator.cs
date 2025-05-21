using APB.AccessControl.Shared.Models.Requests;
using FluentValidation;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.WebApi.Validators
{
    public class CreateAccessPointReqValidator : AbstractValidator<CreateAccessPointReq>
    {
        public CreateAccessPointReqValidator()
        {
            RuleFor(e => e.IpAddress)
                .NotNull().WithMessage(x => NotNull(nameof(x.IpAddress)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.IpAddress)))
                .Matches("^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$").WithMessage(x => InvalidProperty(nameof(x.IpAddress)));

            RuleFor(e => e.Name)
                .NotNull().WithMessage(x => NotNull(nameof(x.Name)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.Name)));

            RuleFor(e => e.AccessPointTypeId)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.AccessPointTypeId)));
        }
    }

    public class UpdateAccessPointReqValidator : AbstractValidator<UpdateAccessPointReq>
    {
        public UpdateAccessPointReqValidator()
        {
            RuleFor(e => e.Id)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.Id)));

            RuleFor(e => e.IpAddress)
                .NotNull().WithMessage(x => NotNull(nameof(x.IpAddress)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.IpAddress)))
                .Matches("^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$").WithMessage(x => InvalidProperty(nameof(x.IpAddress)));

            RuleFor(e => e.Name)
                .NotNull().WithMessage(x => NotNull(nameof(x.Name)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.Name)));
        }
    }
} 