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
        public ColumnPermission(string fullTableName, string columnName,string? description):base(fullTableName, description)
        {
            ColumnName = columnName;
        }

        public void UpdateColumnName(string columnName)
        {
            ColumnName = columnName;
        }
        
    }
}
