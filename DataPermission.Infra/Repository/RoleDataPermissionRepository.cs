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
    public class RoleDataPermissionRepository(AppDbContext dbContext): IRoleDataPermissionRepository
    {

      
        public async Task DeleteByRoleId(long roleId, DataPermissionTypeEnum dataPermissionTypeEnum)
        {
            await dbContext.RoleDataPermissions.Where(t => t.RoleId == roleId&&t.DataPermissionType==dataPermissionTypeEnum).ExecuteDeleteAsync();
        }

        public async Task AddRangeAsync(List<RoleDataPermissionBlackList> entities)
        {
            await dbContext.RoleDataPermissions.AddRangeAsync(entities);
        }
        public async Task AddRangeAsync(long roleId,List<long> dataPermissionIds,DataPermissionTypeEnum dataPermissionTypeEnum)
        {
            List<RoleDataPermissionBlackList> entities = new List<RoleDataPermissionBlackList>();
            foreach (var item in dataPermissionIds)
            {
                entities.Add(new RoleDataPermissionBlackList(roleId, item, dataPermissionTypeEnum));
            }
            await dbContext.RoleDataPermissions.AddRangeAsync(entities);
        }

    }
}
