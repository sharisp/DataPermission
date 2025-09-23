using Domain.SharedKernel.BaseEntity;

namespace DataPermission.Domain.Entities
{
    public class DataPermissionBlackList : BaseEntity
    {
        /// <summary>
        /// include schema name,database name, e.g. Identity.dbo.Users
        /// </summary>
        public string FullTableName { get; private set; } = default!;
        public string? Description { get; private set; }
        protected DataPermissionBlackList() { }
        public DataPermissionBlackList(string fullTableName, string? description)
        {
            FullTableName = fullTableName;
            Description = description;
        }
        public void UpdateTableName(string fullTableName)
        {
            FullTableName = fullTableName;
        }
        public void UpdateDescription(string? description)
        {
            Description = description;
        }
    }
}
