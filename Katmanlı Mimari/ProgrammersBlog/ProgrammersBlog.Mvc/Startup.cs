using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgrammersBlog.Services.AutoMapper.Profiles;
using ProgrammersBlog.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile));
            services.LoadMyServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages(); // olmayan sayfaya gidersek 404 not found
            }
            // statik dosyalarý  kullanmak isticez tema eklicez ve bu temanýn dosyalarýný kullanmaya ihtiyaç duyacaz
            // statik dosyalar->resimler,css, js
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // biz home indexe gidince blog bilgilerini görücez fakat
                // admin home indexe gittigimizde adminle ilgili iþlemlerin index sayfasýný görücez
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"// nullable id
                    // biz eger admin area içerisindeki article indexe gidersek burada eklenmiþ olan tüm makaleleri bir tablo içinde görebiliyor olucaz ->ekleme, silme..
                    // eger sitemizdeki article indexe gidersek buradaki tüm makaleleri blog þemasý üzerinde görecek
                    );
                endpoints.MapDefaultControllerRoute();

            });
        }
    }
}
