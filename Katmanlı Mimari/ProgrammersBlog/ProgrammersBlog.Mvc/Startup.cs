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
            // statik dosyalar�  kullanmak isticez tema eklicez ve bu teman�n dosyalar�n� kullanmaya ihtiya� duyacaz
            // statik dosyalar->resimler,css, js
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // biz home indexe gidince blog bilgilerini g�r�cez fakat
                // admin home indexe gittigimizde adminle ilgili i�lemlerin index sayfas�n� g�r�cez
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"// nullable id
                    // biz eger admin area i�erisindeki article indexe gidersek burada eklenmi� olan t�m makaleleri bir tablo i�inde g�rebiliyor olucaz ->ekleme, silme..
                    // eger sitemizdeki article indexe gidersek buradaki t�m makaleleri blog �emas� �zerinde g�recek
                    );
                endpoints.MapDefaultControllerRoute();

            });
        }
    }
}
