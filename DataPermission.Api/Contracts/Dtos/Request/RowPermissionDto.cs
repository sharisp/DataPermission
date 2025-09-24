using DataPermission.Domain.Enums;

namespace DataPermission.Api.Contracts.Dtos.Request
{
    public class RowPermissionDto
    {
        public string FullTableName { get; set; }
        public string? Description { get; set; }
        public RowDataScopeEnum DataScopeType { get;  set; }
        public RowDataDenyOperateEnum RowDataDenyOperateType { get; set; }
        public string? ScopeField { get;  set; }
        public string? ScopeValue { get;  set; }

    }
}
