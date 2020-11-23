using System;
using System.IO.Pipes;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoList.Business.Services;
using TodoList.Business.Services.Interfaces;
using TodoList.Business.Vo;
using TodoList.Data.Data;
using TodoList.ProjectClient.ApiClient;

namespace TodoList.Web
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllersWithViews();
            services.AddSingleton<IDataProvider<TodoItem>, DataProvider<TodoItem>>();
            services.AddSingleton<IDataProvider<Category>, DataProvider<Category>>();

            services.AddDbContext<AlnaWebApplicationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AlnaWebApplicationContext")));
            services.AddTransient<IEFDataProvider<Category>, EFCategoryProvider>();
            services.AddTransient<IEFDataProvider<TodoItem>, EFTodoItemProvider>();
            services.AddTransient<IEFDataProvider<Tag>, EFTagProvider>();
            services.AddTransient<IEFManyToManyDataProvider<TodoItemTag>, EFTodoItemTagsProvider>();
            services.AddSingleton(new ApiClient("https://localhost:44367"));
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

            app.UseRouting();

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
