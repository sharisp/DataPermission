using DataPermission.Domain.Enums;
using DataPermission.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Services
{
    public class RoleDataPermissionService(IRoleDataPermissionRepository roleDataPermissionRepository)
    {
        public async Task SetRoleDataPermission(long roleId, List<long> dataPermissionIds, DataPermissionTypeEnum dataPermissionTypeEnum)
        {
            await roleDataPermissionRepository.DeleteByRoleId(roleId, dataPermissionTypeEnum);
            await roleDataPermissionRepository.AddRangeAsync(roleId, dataPermissionIds, dataPermissionTypeEnum);
        }
    }
}
