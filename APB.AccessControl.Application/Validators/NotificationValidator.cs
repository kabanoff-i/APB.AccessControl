using APB.AccessControl.Application.Common;
using APB.AccessControl.Domain.Entities;
using FluentValidation;
using System;
using static APB.AccessControl.Application.Common.ValidationMessage;
namespace APB.AccessControl.APB.AccessControl.Application.Validators
{
    public class NotificationValidator: AbstractValidator<Notification>
    {
        public NotificationValidator() 
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
                .GreaterThan(-1)
                .When(e => e.ShowOnPass)
                .WithMessage(e => InvalidProperty(nameof(e.EmployeeId)));
        }

        private bool BeValidExpirationDate(DateTime? expirationDate)
        {
            return expirationDate == null || expirationDate > DateTime.UtcNow;
        }
    }
}
