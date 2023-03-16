using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission11_ajames26.Models;
using Mission11_ajames26.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission11_ajames26
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
            //Use controllers
            services.AddControllersWithViews();

            //Get database connection
            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreConnection"]);
            });

            //Concrete types for interfaces
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();

            //Razor
            services.AddRazorPages();

            //Session
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<Cart>(c => SessionCart.GetCart(c));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "purchase",
                    pattern: "purchase/checkout",
                    defaults: new { controller = "Purchase", action = "Checkout" }
                );

                endpoints.MapControllerRoute(
                    name: "categoryPage",
                    pattern: "{bookCategory}/{pageNum}",
                    defaults: new { Controller = "Home", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    name: "paging",
                    pattern: "{pageNum}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1 }
                );

                endpoints.MapControllerRoute(
                    name: "category",
                    pattern: "{bookCategory}",
                    new { Controller = "Home", action = "Index", pageNum = 1 }
                );

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });
        }
    }
}
