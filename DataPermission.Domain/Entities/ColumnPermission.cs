using Domain.SharedKernel.BaseEntity;
using Domain.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Entities
{
    public class ColumnPermission : DataPermission, IAggregateRoot
    {
        public string ColumnName { get; private set; } = default!;
     
        private ColumnPermission() { }
        public ColumnPermission(string tableName, string columnName,string? description):base(tableName, description)
        {
            ColumnName = columnName;
        }

        public void UpdateColumnName(string columnName)
        {
            ColumnName = columnName;
        }
        
    }
}
