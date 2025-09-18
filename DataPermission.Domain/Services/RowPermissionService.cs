using DataPermission.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Services
{
    public class RowPermissionService
    {
        public List<RowPermission> QueryRowPermissionsByUserID(long userId)
        {
            List<RowPermission> rowPermissions =new List<RowPermission>();

            return rowPermissions;
        }

        public List<RowPermission> QueryRowPermissionsByRoleId(long roleId)
        {
            List<RowPermission> rowPermissions = new List<RowPermission>();

            return rowPermissions;
        }
    }
}
