using Domain.SharedKernel.BaseEntity;
using Domain.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Entities
{
    public class ColumnPermissionBlackList : DataPermissionList, IAggregateRoot
    {
        public string ColumnName { get; private set; } = default!;
     
        private ColumnPermissionBlackList() { }
        public ColumnPermissionBlackList(string fullTableName, string columnName,string? description):base(fullTableName, description)
        {
            ColumnName = columnName;
        }

        public void UpdateColumnName(string columnName)
        {
            ColumnName = columnName;
        }
        
    }
}
