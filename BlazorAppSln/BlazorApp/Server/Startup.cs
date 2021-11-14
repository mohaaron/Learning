using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Data.Repositories;
using BlazorApp.Data.Repositories.Interfaces;
using BlazorApp.Data;
using System.Text.Json.Serialization;

namespace BlazorApp.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddDbContext<BudgetContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
			string fileName = @"\expenses.db";
			string dbFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + fileName;
			services.AddDbContext<BudgetContext>(options => 
				options
					.UseSqlite("Data Source=" + dbFilePath, x => x.MigrationsAssembly("BlazorApp.Data"))
					.EnableSensitiveDataLogging()
			);

			services.AddTransient<IBudgetRepository, BudgetRepository>();
			services.AddTransient<IExpenseRepository, ExpenseRepository>();

			services.AddControllersWithViews().AddJsonOptions(options => {
				options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
				options.JsonSerializerOptions.PropertyNamingPolicy = null; // prevent camel case
			});
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("index.html");
			});
		}
	}
}
