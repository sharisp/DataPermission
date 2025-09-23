using DataPermission.Domain.Entities;
using DataPermission.Domain.Enums;
using DataPermission.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Infra.Repository
{
    public class ColumnPermissionRepository:IColumnDataPermissionRepository
    {
        private AppDbContext dbContext;
        public ColumnPermissionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
      
        public void Delete(ColumnPermissionBlackList info)
        {
           dbContext.ColumnPermissions.Remove(info);
         
        }
     
     
        public async Task AddAsync(ColumnPermissionBlackList entity)
        {
            await dbContext.ColumnPermissions.AddAsync(entity);

      
        }
        public async Task<bool> ExistsConflictAsync(string tableName, string columnName, long? id = null)
        {
            IQueryable<ColumnPermissionBlackList> query = dbContext.ColumnPermissions.AsQueryable();
            query = query.Where(t => t.FullTableName == tableName && t.ColumnName == columnName);
            if (id != null)
            {
                query = query.Where(t => t.Id != id);
            }

            return await query.AnyAsync();
        }
        public async Task<List<ColumnPermissionBlackList>> GetAllByRoleId(long roleId)
        {
            var query = from dp in dbContext.RoleDataPermissions
                        join rp in dbContext.ColumnPermissions on dp.DataPermissionId equals rp.Id
                        where dp.RoleId == roleId && dp.DataPermissionType == DataPermissionTypeEnum.ColumnPermission
                        select rp;

            return await query.ToListAsync();
        }

      
    }
}
