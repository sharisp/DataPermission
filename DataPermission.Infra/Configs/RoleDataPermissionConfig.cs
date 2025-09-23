using DataPermission.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Infra.Configs
{
  public  class RoleDataPermissionBlackListConfig : IEntityTypeConfiguration<RoleDataPermissionBlackList>
    {
        public void Configure(EntityTypeBuilder<RoleDataPermissionBlackList> builder)
        {
            builder.ToTable("T_Role_DataPermissions_BlackList");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();
        }
    }
}