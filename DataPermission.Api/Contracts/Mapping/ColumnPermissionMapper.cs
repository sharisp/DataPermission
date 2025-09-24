using DataPermission.Api.Contracts.Dtos.Request;
using DataPermission.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace DataPermission.Api.Contracts.Mapping
{  

    [Mapper(AllowNullPropertyAssignment = false, ThrowOnPropertyMappingNullMismatch = false)]
    public partial class ColumnPermissionMapper : IMapperService
    {
        public partial ColumnPermissionDto ToDto(ColumnPermissionBlackList info);
        public partial ColumnPermissionBlackList ToEntity(ColumnPermissionDto infoDto);

        private void UpdateEntityFromDto(ColumnPermissionDto inDto, ColumnPermissionBlackList outTarget)
        {
            if (!string.IsNullOrEmpty(inDto.Description)&&inDto.Description!=outTarget.Description)
            {
                outTarget.UpdateDescription(inDto.Description);
            }
            if (!string.IsNullOrEmpty(inDto.FullTableName) && inDto.FullTableName != outTarget.FullTableName)
            {
                outTarget.UpdateTableName(inDto.FullTableName);
            }
           
            if (inDto.ColumnName.ToLower() != outTarget.ColumnName.ToLower())
            {
                outTarget.UpdateColumnName(inDto.ColumnName);
            }
        }

        [UserMapping(Default = true)]

        public void UpdateDtoToEntity(ColumnPermissionDto inDto, ColumnPermissionBlackList outTarget)
        {
            UpdateEntityFromDto(inDto, outTarget);
        }
    }
}
