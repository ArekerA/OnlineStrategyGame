using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineStrategyGame.Base.Galaxy;
using OnlineStrategyGame.Base.Galaxy.Interfaces;
using OnlineStrategyGame.Base.RaceCreator;
using OnlineStrategyGame.Base.RaceCreator.Interfaces;
using OnlineStrategyGame.Database.MSSQL;
using OnlineStrategyGame.Database.MSSQL.Models;
using OnlineStrategyGame.Dtos;
using OnlineStrategyGame.WebApp.Routing;
using System.Collections.Generic;
using System.Globalization;

namespace OnlineStrategyGame.WebApp
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
            CultureInfo[] supportedCultures = new[]
            {
                new CultureInfo("pl"),
                new CultureInfo("en")
            };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<ISolarSystemManager, SolarSystemManager>();
            services.AddScoped<IRaceCreatorManager, RaceCreatorManager>();
            services.AddScoped<IPlanetManager, PlanetManager>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<AppIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("NewPlayerOnly", policy => policy.RequireClaim("NewPlayer"));
                options.AddPolicy("ActivePlayerOnly", policy => policy.RequireClaim("ActivePlayer"));
            });
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("lang", typeof(LanguageRouteConstraint));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
            }
            app.UseRequestLocalization();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
                    pattern: "{lang:lang}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{*catchall}",
                    defaults: new { controller = "Home", action = "RedirectToDefaultLanguage", lang = "en" });



                endpoints.MapRazorPages();
            });
        }
    }
}