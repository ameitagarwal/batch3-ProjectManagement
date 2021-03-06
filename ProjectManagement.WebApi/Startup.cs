using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductManagement.Data;
using ProductManagement.Data.Services;
using ProductManagement.WebAPI.Helpers;
using System;
using System.IO;

namespace ProjectManagement.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ProductDbContext>(
                options =>
                options.UseSqlServer(_config.GetConnectionString("DevConnection"))
                );

            // configure strongly typed settings object
            services.Configure<AppSettings>(_config.GetSection("AppSettings"));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<GenerateToken>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory logger)
        {
            var path = Directory.GetCurrentDirectory();
            logger.AddFile($"{path}\\Logs\\Log.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseExceptionHandlingMiddleware();

            app.UseRouting();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
