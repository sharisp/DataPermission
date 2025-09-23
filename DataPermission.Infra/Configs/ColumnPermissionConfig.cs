using DataPermission.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Infra.Configs
{
    public class ColumnPermissionBlackListConfig : IEntityTypeConfiguration<ColumnPermissionBlackList>
    {
        public void Configure(EntityTypeBuilder<ColumnPermissionBlackList> builder)
        {
            builder.ToTable("T_ColumnPermission_BlackList");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.ColumnName).IsUnicode(false).HasMaxLength(256);
            builder.Property(e => e.FullTableName).IsUnicode(false).HasMaxLength(512);
            builder.Property(e => e.Description).IsUnicode(true).HasMaxLength(512);
        }
    }
}
