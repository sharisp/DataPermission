using DataPermission.Domain.Entities;
using DataPermission.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Infra.Repository
{
    public class ColumnPermissionRepository
    {
        private AppDbContext dbContext;
        public ColumnPermissionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(ColumnPermission entity)
        {
            await dbContext.ColumnPermissions.AddAsync(entity);
        }
        public async Task<List<ColumnPermission>> GetAllByRoleId(long roleId)
        {
            var query = from dp in dbContext.RoleDataPermissions
                        join rp in dbContext.ColumnPermissions on dp.DataPermissionId equals rp.Id
                        where dp.RoleId == roleId && dp.DataPermissionType == DataPermissionTypeEnum.ColumnPermission
                        select rp;

            return await query.ToListAsync();
        }

    }
}
