using BlazorApp.Data.Http.Repositories;
using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			string baseAddress = builder.HostEnvironment.BaseAddress;
			builder.Services.AddScoped<IHttpClientRepository<Budget>>(r => new HttpClientRepository<Budget>(baseAddress, "api/budget"));
			builder.Services.AddScoped<IHttpClientRepository<Expense>>(r => new HttpClientRepository<Expense>(baseAddress, "api/expense"));
			builder.Services.AddScoped<IHttpClientRepository<Income>>(r => new HttpClientRepository<Income>(baseAddress, "api/income"));
			builder.Services.AddScoped<IHttpClientRepository<Debt>>(r => new HttpClientRepository<Debt>(baseAddress, "api/debt"));

			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			builder.Services.AddBlazoredModal();

			await builder.Build().RunAsync();
		}
	}
}
