using APB.AccessControl.Shared.Models.Requests;
using FluentValidation;
using System;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.WebApi.Validators
{
    public class CreateNotificationReqValidator : AbstractValidator<CreateNotificationReq>
    {
        public CreateNotificationReqValidator()
        {
            RuleFor(e => e.AccessPointId)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.AccessPointId)))
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(e => e.Message)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.Message)))
                .NotNull().WithMessage(x => InvalidProperty(nameof(x.Message)));

            RuleFor(e => e.ExpirationDate)
                .Must(BeValidExpirationDate).WithMessage(x => InvalidProperty(nameof(x.ExpirationDate)));

            RuleFor(e => e.EmployeeId)
                .GreaterThan(0)
                .When(e => e.ShowOnPass && e.EmployeeId.HasValue)
                .WithMessage(e => InvalidProperty(nameof(e.EmployeeId)));
        }

        private bool BeValidExpirationDate(DateTime? expirationDate)
        {
            return expirationDate == null || expirationDate > DateTime.UtcNow;
        }
    }

    public class UpdateNotificationReqValidator : AbstractValidator<UpdateNotificationReq>
    {
        public UpdateNotificationReqValidator()
        {
            RuleFor(e => e.Id)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.Id)));
                
            RuleFor(e => e.AccessPointId)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.AccessPointId)))
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(e => e.Message)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.Message)))
                .NotNull().WithMessage(x => InvalidProperty(nameof(x.Message)));

            RuleFor(e => e.ExpirationDate)
                .Must(BeValidExpirationDate).WithMessage(x => InvalidProperty(nameof(x.ExpirationDate)));

            RuleFor(e => e.EmployeeId)
                .GreaterThan(0)
                .When(e => e.ShowOnPass && e.EmployeeId.HasValue)
                .WithMessage(e => InvalidProperty(nameof(e.EmployeeId)));
        }

        private bool BeValidExpirationDate(DateTime? expirationDate)
        {
            return expirationDate == null || expirationDate > DateTime.UtcNow;
        }
    }
} 