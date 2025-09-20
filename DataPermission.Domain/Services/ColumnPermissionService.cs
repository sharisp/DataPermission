using DataPermission.Domain.Entities;
using DataPermission.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Services
{
    public class ColumnPermissionService(IColumnDataPermissionRepository repository)
    {
        public async Task<bool> ExistsConflictAsync(string tableName, string columnName, long? id = null)
        {
            return await repository.ExistsConflictAsync(tableName, columnName, id);
        }
    }
}
