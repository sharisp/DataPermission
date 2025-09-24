using DataPermission.Api.Contracts.Dtos.Request;
using DataPermission.Domain.Entities;
using DataPermission.Domain.Enums;
using FluentValidation;

namespace DataPermission.Api.Contracts.Validator
{
    public class RowPermissionValidator : FluentValidation.AbstractValidator<RowPermissionDto>
    {
        public RowPermissionValidator()
        {
            RuleFor(x => x.DataScopeType).Must(value => Enum.IsDefined(typeof(RowDataScopeEnum), value));

            RuleFor(x => x.FullTableName)
                .NotEmpty().WithMessage("TableName is required.")
                .Length(3, 50).WithMessage("TableName must be between 3 and 50 characters.");

            RuleFor(x => x.Description)
                .Length(3, 250).When(x => !string.IsNullOrEmpty(x.Description))
                .WithMessage("Description must be between 3 and 50 characters.");

            RuleFor(x => x.ScopeField)
               .Length(3, 250).When(x => !string.IsNullOrEmpty(x.ScopeField))
               .WithMessage("ScopeField must be between 3 and 50 characters.");

            RuleFor(x => x.ScopeValue)
             .Length(0, 250).When(x => !string.IsNullOrEmpty(x.ScopeValue))
             .WithMessage("ScopeValue mu.st be between 0 and 50 characters.");
         
        }
    }
}
