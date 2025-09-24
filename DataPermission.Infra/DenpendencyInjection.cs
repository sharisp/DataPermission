using DataPermission.Domain;
using DataPermission.Domain.Interfaces;
using DataPermission.Infra.Repository;
using Infrastructure.SharedKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Infra
{
    public static class DenpendencyInjection
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureKernelCollection(configuration);
            services.AddScoped<IColumnDataPermissionRepository, ColumnPermissionRepository>();
            services.AddScoped<IRowDataPermissionRepository, RowPermissionRepository>();
            services.AddScoped<IRoleDataPermissionRepository, RoleDataPermissionRepository>();

            services.AddScoped<CommonQuery>();          
            services.AddDomain(configuration);


        }
    }
}
