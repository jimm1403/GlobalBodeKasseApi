using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalBodeKasse.Core.ApplicationService;
using GlobalBodeKasse.Core.ApplicationService.Service;
using GlobalBodeKasse.Core.DomainService;
using GlobalBodeKasse.Infrastructure.Data;
using GlobalBodeKasse.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GlobalBodeKasseApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                services.AddDbContext<GlobalDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GlobalConnection")));
            }
            else
            {
                services.AddDbContext<GlobalDbContext>(options => options.UseSqlite("Data Source=GlobalBodeKasse.db"));
            }

            services.BuildServiceProvider().GetService<GlobalDbContext>().Database.Migrate();

            //services.AddEntityFrameworkSqlServer().AddDbContext<GlobalDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("GlobalConnection")));

            //services.AddDbContext<GlobalDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("GlobalConnection")));

            //services.AddEntityFrameworkSqlite().AddDbContext<GlobalDbContext>(options => options.UseSqlite("Data Source=GlobalBodeKasse.db"));

            services.AddScoped<IGroupSpaceRepository, GroupSpaceRepository>();
            services.AddScoped<IGroupSpaceService, GroupSpaceService>();

            services.AddScoped<IUserGroupSpaceRepository, UserGroupSpaceRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<GlobalDbContext>();
                    DatabaseTestSeeder.SeedGlobalDb(ctx);
                    
                }
            }
            else
            {
                app.UseHsts();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<GlobalDbContext>();
                    DatabaseTestSeeder.SeedGlobalDb(ctx);
                }
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
