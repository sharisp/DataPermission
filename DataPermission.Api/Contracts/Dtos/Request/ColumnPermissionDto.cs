namespace DataPermission.Api.Contracts.Dtos.Request
{
    public class ColumnPermissionDto
    {
        public string FullTableName { get;  set; }
        public string? Description { get;  set; }
        public string ColumnName { get;  set; }
    }
}
