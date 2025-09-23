using DataPermission.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Interfaces
{
    public interface IColumnDataPermissionRepository
    {
        void Delete(ColumnPermissionBlackList info);
        Task<bool> ExistsConflictAsync(string tableName, string columnName, long? id = null);
    
        Task AddAsync(ColumnPermissionBlackList entity);
        Task<List<ColumnPermissionBlackList>> GetAllByRoleId(long roleId);
    }
}
