using Domain.SharedKernel.BaseEntity;
using Domain.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Entities
{
    public class ColumnPermission : BaseEntity, IAggregateRoot
    {
        public string TableName { get; private set; }
        public string ColumnName { get; private set; }
        public string? Description { get; set; }
        private ColumnPermission() { }
        public ColumnPermission(string tableName, string columnName)
        {
            TableName = tableName;
            ColumnName = columnName;
        }

        public void UpdateColumnName(string columnName)
        {
            ColumnName = columnName;
        }
        public void UpdateTableName(string tableName)
        {
            TableName = tableName;
        }
    }
}
