using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Orphanage.Models;
using Microsoft.AspNetCore.Identity;
namespace Orphanage
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("https://unsplash.com");
                                  });
            });
            services.AddDbContext<NGODbContext>(opts => {
                opts.UseSqlServer(
                Configuration["ConnectionStrings:NGOConnection"]);
            });
            services.AddScoped<INGORepository, EFNGORepository>();
            services.AddControllersWithViews();
            services.AddMvc().AddSessionStateTempDataProvider();

            services.AddSession();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();

            //services.AddDbContext<AppIdentityDbContext>(options =>
            //options.UseSqlServer(
            //Configuration["ConnectionStrings:IdentityConnection"]));
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //.AddEntityFrameworkStores<AppIdentityDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //IdentitySeedData.EnsurePopulated(app);
        }
    }
}
