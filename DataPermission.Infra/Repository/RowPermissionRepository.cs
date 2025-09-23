using DataPermission.Domain.Entities;
using DataPermission.Domain.Enums;
using DataPermission.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Infra.Repository
{
    public class RowPermissionRepository : IRowDataPermissionRepository
    {
        private readonly AppDbContext dbContext;

        public RowPermissionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
      
        public void Delete(RowPermissionBlackList info)
        {
            dbContext.RowPermissions.Remove(info);
        }
        public async Task BatchDelete(List<long> ids)
        {
            if (ids == null || ids.Count == 0)
                return;
            await dbContext.RowPermissions.Where(t => ids.Contains(t.Id)).ExecuteDeleteAsync();
        }
        public async Task AddAsync(RowPermissionBlackList entity)
        {
            await dbContext.RowPermissions.AddAsync(entity);
        }
        public async Task<List<RowPermissionBlackList>> GetAllByRoleId(long roleId)
        {
            var query = from dp in dbContext.RoleDataPermissions
                        join rp in dbContext.RowPermissions on dp.DataPermissionId equals rp.Id
                        where dp.RoleId == roleId && dp.DataPermissionType == DataPermissionTypeEnum.RowPermission
                        select rp;

            return await query.ToListAsync();
        }

        public async Task<bool> ExistsConflictAsync(string tableName, RowDataScopeEnum dataScopeType, string scopeValue, string scopeField, long? id = null)
        {
            var query = dbContext.RowPermissions.AsQueryable();
            query = query.Where(t => t.FullTableName == tableName && t.DataScopeType == dataScopeType);

            if (dataScopeType == RowDataScopeEnum.Custom)
            {
                query = query.Where(t => t.ScopeValue == scopeValue && t.ScopeField == scopeField);
            }

            if (id != null)
            {
                query = query.Where(t => t.Id == id);
            }

            return await query.AnyAsync();
        }
    }
}
