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
        }
    }
}
