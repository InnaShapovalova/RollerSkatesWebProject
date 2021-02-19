using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rollers.Data.Contexts;
using Rollers.Data.Repositories;
using Rollers.Domain.Abstractions;

namespace Rollers
{
    public class Startup
    {
        private readonly AppConfiguration _appConfiguration = new AppConfiguration();


        public Startup(IConfiguration configuration)
        {
            configuration.Bind(_appConfiguration);
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_appConfiguration);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_appConfiguration.DbSettings.MsSqlConnectionString));
            services.AddScoped<IRollerSkateMapLocationRepository, RollerSkateMapLocationMsSqlRepository>();
            services.AddScoped<IUserRepository, UserMsSqlRepository>();
            services.AddScoped<ICommentRepository, CommentMsSqlRepository>();
            services.AddControllersWithViews();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });


        }
    }
}
