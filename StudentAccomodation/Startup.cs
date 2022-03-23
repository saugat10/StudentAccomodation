using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Student_Accomodation.Services.ADOServices.ADOApartmentServices;
using Student_Accomodation.Services.ADOServices.ADODormitoryServices;
using Student_Accomodation.Services.ADOServices.ADOLeasingServices;
using Student_Accomodation.Services.ADOServices.ADORoomServices;
using Student_Accomodation.Services.ADOServices.ADOStudentServices;
using Student_Accomodation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation
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
            services.AddRazorPages();

            services.AddScoped<IApartmentService, ADOApartmentService>();
            services.AddScoped<IDormitoryService, ADODormitoryService>();
            services.AddScoped<ILeasingService, ADOLeasingService>();
            services.AddScoped<IRoomService, ADORoomService>();
            services.AddScoped<IStudentService, ADOStudentService>();
            

            services.AddScoped<ADOApartment>();
            services.AddScoped<ADODormitory>();
            services.AddScoped<ADOLeasing>();
            services.AddScoped<ADORoom>();
            services.AddScoped<ADOStudent>();
            
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
