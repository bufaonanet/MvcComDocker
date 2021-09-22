using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MvcComDocker.context;
using MvcComDocker.context.repositories;
using System;

namespace MvcComDocker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //var connectionString = Configuration.GetConnectionString("Default");

            var host = Configuration["DBHOST"] ?? "localhost";
            var port = Configuration["DBPORT"] ?? "3306";
            var password = Configuration["DBPASSWORD"] ?? "admin";

            services.AddDbContext<MvcomDockerContext>(options =>
                options.UseMySql($"server={host};userid=root;pwd={password};port={port};database=produtosdb", 
                new MySqlServerVersion(new Version(5, 7, 35))));

            //services.AddDbContext<MvcomDockerContext>(ops => 
            //ops.UseMySql(connectionString, new MySqlServerVersion(new Version(5, 7, 35))));

            //services.AddDbContext<MvcomDockerContext>(ops => ops.UseInMemoryDatabase("Produtos"));

            services.AddControllersWithViews();

            services.AddTransient<IRepository, ProdutoRepository>();
        }

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

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //PopulaDb.IncluiDadosDB(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
