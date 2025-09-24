using DataPermission.Domain.Entities;
using DataPermission.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Interfaces
{
    public interface IRowDataPermissionRepository
    {
     
        void Delete(RowPermissionList info);
       
        Task BatchDelete(List<long> ids);
        Task AddAsync(RowPermissionList entity);
        Task<List<RowPermissionList>> GetAllByRoleId(long roleId);
        Task<bool> ExistsConflictAsync(string tableName, RowDataScopeEnum dataScopeType, string? scopeValue, string? scopeField, long? id = null);
    }
}
