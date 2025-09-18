using Domain.SharedKernel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Entities
{
    public class DataPermission:BaseEntity
    {
        public string TableName { get; private set; }=default!;
        public string? Description { get;private set; }
        protected DataPermission() { }
        public DataPermission(string tableName, string? description)
        {
            TableName = tableName;
            Description = description;
        }
        public void UpdateTableName(string tableName)
        {
            TableName = tableName;
        }
    }
}
