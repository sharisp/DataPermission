using DataPermission.Domain.Entities;
using Infrastructure.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Infra.Repository
{
    public class AppDbContext : BaseDbContext
    {
       

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<RowPermissionList> RowPermissions { get; set; }
        public DbSet<ColumnPermissionBlackList> ColumnPermissions { get; set; }
        public DbSet<RoleDataPermissionList> RoleDataPermissions { get; set; }
    }
}
