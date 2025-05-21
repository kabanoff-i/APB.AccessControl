using APB.AccessControl.Shared.Models.Filters;
using APB.AccessControl.Shared.Models.Requests;
using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.WebApi.Validators
{
    public class CreateAccessRuleReqValidator : AbstractValidator<CreateAccessRuleReq>
    {
        public CreateAccessRuleReqValidator()
        {
            RuleFor(e => e.AccessGroupId)
                .GreaterThan(0)
                .WithMessage(x => InvalidProperty(nameof(x.AccessGroupId)));

            RuleFor(e => e.AccessPointId)
                .GreaterThan(0)
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
                .Must(BeValidJsonDateArray)
                .When(x => !string.IsNullOrEmpty(x.SpecificDates));

            RuleFor(x => x.DaysOfWeek)
                .NotNull().WithMessage(x => NotNull(nameof(x.DaysOfWeek)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.DaysOfWeek)))
                .Must(x => x.Length == 7).WithMessage(x => InvalidProperty(nameof(x.DaysOfWeek)));

            RuleFor(a => a.StartDate)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.StartDate)))
                .LessThan(a => a.EndDate)
                .WithMessage(x => InvalidProperty(nameof(x.StartDate)));

            RuleFor(a => a.EndDate)
                .GreaterThan(a => a.StartDate)
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

    public class UpdateAccessRuleReqValidator : AbstractValidator<UpdateAccessRuleReq>
    {
        public UpdateAccessRuleReqValidator()
        {
            RuleFor(e => e.Id)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.Id)));

            RuleFor(e => e.AccessGroupId)
                .GreaterThan(0)
                .WithMessage(x => InvalidProperty(nameof(x.AccessGroupId)));

            RuleFor(e => e.AccessPointId)
                .GreaterThan(0)
                .WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));

            RuleFor(a => a.AllowedTimeStart)
                .NotNull().WithMessage(x => NotNull(nameof(x.AllowedTimeStart)))
                .LessThan(a => a.AllowedTimeEnd)
                .WithMessage(x => InvalidProperty(nameof(x.AllowedTimeStart)));

            RuleFor(a => a.AllowedTimeEnd)
                .NotNull().WithMessage(x => NotNull(nameof(x.AllowedTimeEnd)))
                .GreaterThan(a => a.AllowedTimeStart)
                .WithMessage(x => InvalidProperty(nameof(x.AllowedTimeEnd)));

            RuleFor(x => x.SpecificDates)
                .Must(BeValidJsonDateArray)
                .When(x => !string.IsNullOrEmpty(x.SpecificDates));

            RuleFor(x => x.DaysOfWeek)
                .NotNull().WithMessage(x => NotNull(nameof(x.DaysOfWeek)))
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.DaysOfWeek)))
                .Must(x => x.Length == 7).WithMessage(x => InvalidProperty(nameof(x.DaysOfWeek)));

            RuleFor(a => a.StartDate)
                .NotEmpty().WithMessage(x => NotEmpty(nameof(x.StartDate)))
                .LessThan(a => a.EndDate)
                .WithMessage(x => InvalidProperty(nameof(x.StartDate)));

            RuleFor(a => a.EndDate)
                .GreaterThan(a => a.StartDate)
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

    public class AccessRuleFilterDtoValidator : AbstractValidator<AccessRuleFilterDto>
    {
        public AccessRuleFilterDtoValidator()
        {
            RuleFor(e => e.AccessGroupId)
                .GreaterThan(0).When(x => x.AccessGroupId.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.AccessGroupId)));

            RuleFor(e => e.AccessPointId)
                .GreaterThan(0).When(x => x.AccessPointId.HasValue)
                .WithMessage(x => InvalidProperty(nameof(x.AccessPointId)));
        }
    }
} 