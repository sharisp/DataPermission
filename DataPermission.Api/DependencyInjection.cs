using Common.Jwt;
using DataPermission.Infra;
using Domain.SharedKernel.Interfaces;
using Infrastructure.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;
using FluentValidation;
using DataPermission.Api.Controllers;
using DataPermission.Infra.Repository;
using System.Text.Json.Serialization;
using DataPermission.Api.Contracts.Mapping;
using DataPermission.Api.ActionFilter;
using Microsoft.Extensions.Options;

namespace DataPermission.Api
{
    public static class DependencyInjection
    {
        public static void AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<UnitOfWorkActionFilter>();

            services.AddControllers(options => options.Filters.AddService<UnitOfWorkActionFilter>()).ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>

                     new BadRequestObjectResult(ApiResponse<string>.Fail("param error"));

            }).AddJsonOptions(options =>
            {
                //configure json options,long type bug
                options.JsonSerializerOptions.NumberHandling =
                    System.Text.Json.Serialization.JsonNumberHandling.WriteAsString
                    | System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            services.AddEndpointsApiExplorer();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
              typeof(IUnitOfWork).Assembly,
                   typeof(RowDataPermissionController).Assembly,
              Assembly.GetExecutingAssembly()
          // typeof(AlbumController).Assembly //
          ));
            // 如果是多个DB，这儿可以改成 自定义的DBContext, 继承于DbContext即可
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });
            services.AddScoped<BaseDbContext>(sp => sp.GetRequiredService<AppDbContext>());

            services.AddHttpContextAccessor(); //for accessing HttpContext in services IHttpContextAccessor
                                               // services.AddSwaggerGen();
            services.AddJWTAuthentication(configuration);
            services.AddAllMapper();
            // builder.Services.AddDomainCollection(builder.Configuration);


        }
    }
}
