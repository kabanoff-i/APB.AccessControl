using FluentValidation;
using static APB.AccessControl.Application.Common.ValidationMessage;
using APB.AccessControl.Domain.Entities;
using APB.AccessControl.Application.Common;
using System;

namespace APB.AccessControl.Application.Validators
{
    public class AccessGridValidator: AbstractValidator<AccessGrid>
    {
        public AccessGridValidator()
        {
            RuleFor(e => e.EmployeeId)
                .GreaterThan(-1).WithMessage(x => InvalidProperty(nameof(x.EmployeeId)));

            RuleFor(e => e.GroupId)
                .GreaterThan(-1).WithMessage(x => InvalidProperty(nameof(x.GroupId)));
        }

    }
}
