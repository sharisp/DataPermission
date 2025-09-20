using DataPermission.Domain.Entities;
using DataPermission.Domain.Enums;
using DataPermission.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Services
{
    public class RowPermissionService(IRowDataPermissionRepository repository)
    {
        public async Task<bool> ExistsConflictAsync(string tableName, RowDataScopeEnum dataScopeType, string? scopeValue, string? scopeField, long? id = null)
        {
            return await repository.ExistsConflictAsync(tableName, dataScopeType, scopeValue, scopeField, id);
        }
    }
}
