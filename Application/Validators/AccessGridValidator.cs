using FluentValidation;
using static Application.Common.ValidationMessage;
using Domain.Entities;
using Application.Common;
using System;

namespace Application.Validators
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
