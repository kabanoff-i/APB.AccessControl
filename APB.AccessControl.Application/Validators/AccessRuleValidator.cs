using FluentValidation;
using APB.AccessControl.Domain.Entities;
using static APB.AccessControl.Application.Common.ValidationMessage;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using System;

namespace APB.AccessControl.Application.Validators
{
    public class AccessRuleValidator: AbstractValidator<AccessRule>
    {
        public AccessRuleValidator() 
        {
            RuleFor(e => e.AccessGroupId)
                .GreaterThan(-1)
                .WithMessage(x => InvalidProperty(nameof(x.AccessGroupId)));

            RuleFor(e => e.AccessPointId)
                .GreaterThan(-1)
                .WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(a => a.AllowedTimeStart)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.AllowedTimeStart)))
                .LessThan(a => a.AllowedTimeEnd)
                .WithMessage(x => InvalidProperty(nameof(x.AllowedTimeStart)));

            RuleFor(a => a.AllowedTimeEnd)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.AllowedTimeEnd)))
                .GreaterThan(a => a.AllowedTimeStart)
                .WithMessage(x => InvalidProperty(nameof(x.AllowedTimeEnd)));

            RuleFor(x => x.SpecificDates)
                .Must(BeValidJsonDateArray);

            RuleFor(x => x.DaysOfWeek)
                .NotNull().WithMessage(x => NotNull(nameof(x.DaysOfWeek)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.DaysOfWeek)))
                .Must(x => x.Length == 7).WithMessage(x => InvalidProperty(nameof(x.DaysOfWeek)));

            RuleFor(a => a.StartDate)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.StartDate)))
                .LessThan(a => a.EndDate)
                .When(a => a.EndDate != null && a.EndDate != default)
                .WithMessage(x => InvalidProperty(nameof(x.StartDate)));

            RuleFor(a => a.EndDate)
                .GreaterThan(a => a.StartDate)
                .When(a => a.EndDate != null && a.EndDate != default)
                .WithMessage(x => InvalidProperty(nameof(x.EndDate)));
        }

        private bool BeValidJsonDateArray(string specificDatesJson)
        {
            if (string.IsNullOrWhiteSpace(specificDatesJson))
                return true; 

            try
            {
                var dates = JsonConvert.DeserializeObject<List<DateTime>>(specificDatesJson);
                return dates != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
