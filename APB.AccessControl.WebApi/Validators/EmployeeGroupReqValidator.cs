using APB.AccessControl.Shared.Models.Requests;
using FluentValidation;
using static APB.AccessControl.Shared.Utils.ValidationMessage;

namespace APB.AccessControl.WebApi.Validators
{
    public class AddEmployeeToGroupReqValidator : AbstractValidator<AddEmployeeToGroupReq>
    {
        public AddEmployeeToGroupReqValidator()
        {
            RuleFor(e => e.EmployeeId)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.EmployeeId)));

            RuleFor(e => e.AccessGroupId)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.AccessGroupId)));
        }
    }

    public class RemoveEmployeeFromGroupReqValidator : AbstractValidator<RemoveEmployeeFromGroupReq>
    {
        public RemoveEmployeeFromGroupReqValidator()
        {
            RuleFor(e => e.EmployeeId)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.EmployeeId)));

            RuleFor(e => e.AccessGroupId)
                .GreaterThan(0).WithMessage(x => InvalidProperty(nameof(x.AccessGroupId)));
        }
    }
} 