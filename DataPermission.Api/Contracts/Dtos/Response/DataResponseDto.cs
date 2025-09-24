using DataPermission.Domain.Entities;

namespace DataPermission.Api.Contracts.Dtos.Response
{
    public record DataResponseDto
    {
        public List<RowPermissionBlackList> RowPermissions { get; set; }
        public List<ColumnPermissionBlackList> ColumnPermissions { get; set; }
        public DataResponseDto(List<RowPermissionBlackList> rowPermissions, List<ColumnPermissionBlackList> columnPermissions)
        {
            RowPermissions = rowPermissions;
            ColumnPermissions = columnPermissions;
        }
    }
}
