using Domain.SharedKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain
{
    public static class DenpendencyInjection
    {
        public static void AddDomain(this IServiceCollection services,IConfiguration configuration)
        {
         //   services.AddDomainShardKernelCollection(configuration);



        }
    }
}
