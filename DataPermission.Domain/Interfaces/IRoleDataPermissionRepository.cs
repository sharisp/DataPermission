using DataPermission.Domain.Entities;
using DataPermission.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Interfaces
{
    public interface IRoleDataPermissionRepository
    {
        Task DeleteByRoleId(long roleId, DataPermissionTypeEnum dataPermissionTypeEnum);

        Task AddRangeAsync(List<RoleDataPermissionList> entities);

        Task AddRangeAsync(long roleId, List<long> dataPermissionIds, DataPermissionTypeEnum dataPermissionTypeEnum);
       
    }
}
