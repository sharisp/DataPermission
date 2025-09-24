using DataPermission.Api.Contracts.Dtos.Request;
using DataPermission.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace DataPermission.Api.Contracts.Mapping
{  

    [Mapper(AllowNullPropertyAssignment = false, ThrowOnPropertyMappingNullMismatch = false)]
    public partial class RowPermissionMapper : IMapperService
    {
        public partial RowPermissionDto ToDto(RowPermissionList info);
        public partial RowPermissionList ToEntity(RowPermissionDto infoDto);

        private void UpdateEntityFromDto(RowPermissionDto inDto, RowPermissionList outTarget)
        {
            if (!string.IsNullOrEmpty(inDto.Description)&&inDto.Description!=outTarget.Description)
            {
                outTarget.UpdateDescription(inDto.Description);
            }
            if (!string.IsNullOrEmpty(inDto.FullTableName) && inDto.FullTableName != outTarget.FullTableName)
            {
                outTarget.UpdateTableName(inDto.FullTableName);
            }
            if (inDto.DataScopeType != outTarget.DataScopeType)
            {
                outTarget.UpdateDataScopeType(inDto.DataScopeType);
            }
            if (inDto.RowDataAllowOperateType != outTarget.RowDataAllowOperateType)
            {
                outTarget.UpdateDataScopeType(inDto.DataScopeType);
            }
            if (inDto.ScopeValue != outTarget.ScopeValue)
            {
                outTarget.UpdateScopeValue(inDto.ScopeValue);
            }
            if (inDto.ScopeField != outTarget.ScopeField)
            {
                outTarget.UpdateScopeField(inDto.ScopeField);
            }
        }

        [UserMapping(Default = true)]

        public void UpdateDtoToEntity(RowPermissionDto inDto, RowPermissionList outTarget)
        {
            UpdateEntityFromDto(inDto, outTarget);
        }
    }
}
