using Domain.SharedKernel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Entities
{
    public class DataPermission : BaseEntity
    {
        /// <summary>
        /// include schema name,database name, e.g. Identity.dbo.Users
        /// </summary>
        public string FullTableName { get; private set; } = default!;
        public string? Description { get; private set; }
        protected DataPermission() { }
        public DataPermission(string fullTableName, string? description)
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
