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
    public class RowPermissionConfig : IEntityTypeConfiguration<RowPermission>
    {
        public void Configure(EntityTypeBuilder<RowPermission> builder)
        {
            builder.ToTable("T_Row_Permissions");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.ScopeField).IsUnicode(false).HasMaxLength(256);

            builder.Property(e => e.TableName).IsUnicode(false).HasMaxLength(256);
        }
    }
}

