using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Data.Http.Repositories
{
	public class BudgetHttpRepository : IBudgetRepository
	{
		private readonly HttpClient httpClient;

		public BudgetHttpRepository(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<Budget> GetBudget(int id)
		{
			Budget budget = null;
			try
			{
				budget = await httpClient.GetFromJsonAsync<Budget>("api/Budget/" + id);
			}
			catch(Exception x)
			{
				x.ToString();
			}
			return budget;
		}

		public async Task<DbTaskResult> SaveBudget(Budget budget)
		{
			var resp = await httpClient.PutAsJsonAsync<Budget>("api/Budget", budget);
			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}
	}
}
