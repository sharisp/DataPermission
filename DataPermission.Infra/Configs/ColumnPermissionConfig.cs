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
    public class ColumnPermissionConfig : IEntityTypeConfiguration<ColumnPermission>
    {
        public void Configure(EntityTypeBuilder<ColumnPermission> builder)
        {
            builder.ToTable("T_Column_Permissions");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.ColumnName).IsUnicode(false).HasMaxLength(256);
            builder.Property(e => e.TableName).IsUnicode(false).HasMaxLength(256);
        }
    }
}
