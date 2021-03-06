using Castle.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Del1.DAL;

namespace WebApp_Del1
{
    public class Startup
    {
        

       // public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<BillettContext>(options => options.UseSqlite("Data source =Billett.db")); //Skal endres etterhvert.
            services.AddScoped<IBillettRepository, BillettRepository>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {   
                app.UseDeveloperExceptionPage();
                DBInit.Initialize(app);
                loggerFactory.AddFile("Logs/KundeLog.txt");
            }

           // app.UseDefaultFiles(); 
            app.UseStaticFiles(); // merk denne!
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
