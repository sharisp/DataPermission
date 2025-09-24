
using DataPermission.Api.MiddleWares;
using DataPermission.Infra;
using FileService.Api.MiddleWares;
using Microsoft.AspNetCore.Authorization;

namespace DataPermission.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApi(builder.Configuration);
            builder.Services.AddInfra(builder.Configuration);
            var app = builder.Build();

            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseMiddleware<CustomerExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

           // app.UseCors();
            //   app.UseForwardedHeaders();
            //app.UseHttpsRedirection();//不能与ForwardedHeaders很好的工作，而且webapi项目也没必要配置这个
            app.UseAuthorization();

            app.MapGet("/", [AllowAnonymous] () => "Hello from Data Permission!");



            app.MapControllers();

           app.UseMiddleware<CustomPermissionCheckMiddleware>();
            app.Run();
        }
    }
}
