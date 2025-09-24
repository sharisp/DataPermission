using DataPermission.Api.Contracts.Dtos.Request;
using FluentValidation;

namespace DataPermission.Api.Contracts.Validator
{

    public class ColumnPermissionValidator : FluentValidation.AbstractValidator<ColumnPermissionDto>
    {
        public ColumnPermissionValidator()
        {

            RuleFor(x => x.FullTableName)
                .NotEmpty().WithMessage("TableName is required.")
                .Length(3, 50).WithMessage("TableName must be between 3 and 50 characters.");
          
            RuleFor(x => x.ColumnName)
               .NotEmpty().WithMessage("ColumnName is required.")
               .Length(3, 50).WithMessage("ColumnName must be between 3 and 50 characters.");


            RuleFor(x => x.Description)
                .Length(3, 250).When(x => !string.IsNullOrEmpty(x.Description))
                .WithMessage("Description must be between 3 and 50 characters.");
        }
    }
}