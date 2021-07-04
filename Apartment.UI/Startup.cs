using System;
using ApartmentMng.Business.Abstract;
using ApartmentMng.Business.Concrete;
using ApartmentMng.Core.Repository.Abstract;
using ApartmentMng.Core.Settings;
using ApartmentMng.DataAccess.Abstract;
using ApartmentMng.DataAccess.Concrete;
using ApartmentMng.DataAccess.Repository;
using ApartmentMng.Entities.Concrete;
using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apartment.UI
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
            services.AddAuthentication(option =>
            {
                option.DefaultScheme = IdentityConstants.ApplicationScheme;
                option.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies(op =>
            {


            });

            services.AddIdentityCore<Personel>(option =>
            {

            })
                .AddRoles<MongoIdentityRole>()
                .AddMongoDbStores<Personel, MongoIdentityRole, Guid>(Configuration.GetSection("MongoConnection:ConnectionString").Value, Configuration.GetSection("MongoConnection:Database").Value)
                .AddSignInManager()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.HttpOnly = true;
                option.ExpireTimeSpan = TimeSpan.FromMinutes(5);  // 5 dk sonra iþlem yapýlmazsa oturum kapanýyor.
                option.LoginPath = "/Account/Login";
                option.SlidingExpiration = true;

            });

            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });
            services.AddScoped(typeof(IRepository<>), typeof(MongoRepositoryBase<>));

            services.AddScoped<IPersonelRepository, PersonelRepository>();
            services.AddScoped<IPersonelService, PersonelManager>();

            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IApartmentService, ApartmentManager>();

            services.AddScoped<IHousingRepository, HousingRepository>();
            services.AddScoped<IHousingService, HousingManager>();

            services.AddControllersWithViews();
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

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
