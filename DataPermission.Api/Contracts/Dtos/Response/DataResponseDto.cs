using DataPermission.Domain.Entities;

namespace DataPermission.Api.Contracts.Dtos.Response
{
    public record DataResponseDto
    {
        public List<RowPermissionList> RowPermissions { get; set; }
        public List<ColumnPermissionBlackList> ColumnPermissions { get; set; }
        public DataResponseDto(List<RowPermissionList> rowPermissions, List<ColumnPermissionBlackList> columnPermissions)
        {
            RowPermissions = rowPermissions;
            ColumnPermissions = columnPermissions;
        }
    }
}
