using DataPermission.Domain.Enums;
using Domain.SharedKernel.BaseEntity;
using Domain.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Entities
{
    public class RoleDataPermissionBlackList:BaseEntity,IAggregateRoot
    {
        public  long RoleId { get; set; }
        public long DataPermissionId { get; set; }
        public DataPermissionTypeEnum DataPermissionType { get; set; }

        private RoleDataPermissionBlackList() { }
        public RoleDataPermissionBlackList(long roleId, long dataPermissionId, DataPermissionTypeEnum dataPermissionType)
        {
            RoleId = roleId;
            DataPermissionId = dataPermissionId;
            DataPermissionType = dataPermissionType;
        }
    }
}
