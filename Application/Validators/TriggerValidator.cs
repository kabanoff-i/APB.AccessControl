using FluentValidation;
using Domain.Entities;
using static Application.Common.ValidationMessage;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using System;


namespace Application.Validators
{
    public class TriggerValidator: AbstractValidator<Trigger>
    {
        public TriggerValidator() 
        {
            RuleFor(x => x.AccessPointId)
                .GreaterThan(-1).WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(x => x.ActionTypeId)
                .GreaterThan(-1).WithMessage(x => InvalidProperty(nameof(x.ActionTypeId)));

            RuleFor(x => x.AccessResult)
                .IsInEnum().WithMessage(x => InvalidProperty(nameof(x.ActionTypeId)));

            RuleFor(x => x.ActionValue)
                .NotNull().WithMessage(x => NotNull(nameof(x.ActionValue)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.ActionValue)));
        }
    }
}
