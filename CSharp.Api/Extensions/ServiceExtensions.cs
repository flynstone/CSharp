using AutoMapper;
using CSharp.Application.Articles;
using CSharp.Application.Core;
using CSharp.Application.Interfaces;
using CSharp.Data;
using CSharp.Infrastructure.Email;
using CSharp.Infrastructure.Photos;
using CSharp.Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CSharp.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials()
                       .WithExposedHeaders("WWW-Authenticate", "Pagination")
                       .WithOrigins("http://localhost:3000"));
            });

        public static void ConfigureScopes(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CSharp.Api", Version = "v1" });
            });
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddMediatR(typeof(List.Handler));
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddSignalR();
            services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));
            services.AddScoped<EmailSender>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("sqlConnection"), (b => b.MigrationsAssembly("CSharp.Data"))));
        }
    }
}
