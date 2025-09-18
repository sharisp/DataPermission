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
    public class RowPermissionRepository
    {
        private readonly AppDbContext dbContext;

        public RowPermissionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(RowPermission entity)
        {
            await dbContext.RowPermissions.AddAsync(entity);
        }
        public async Task<List<RowPermission>> GetAllByRoleId(long roleId)
        {
            var query = from dp in dbContext.RoleDataPermissions
                        join rp in dbContext.RowPermissions on dp.DataPermissionId equals rp.Id
                        where dp.RoleId == roleId && dp.DataPermissionType == DataPermissionTypeEnum.RowPermission
                        select rp;

            return await query.ToListAsync();
        }
    }
}
