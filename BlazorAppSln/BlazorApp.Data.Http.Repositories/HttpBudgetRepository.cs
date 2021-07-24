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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp.Data.Http.Repositories
{
	public class HttpBudgetRepository : HttpRepositoryBase, IBudgetRepository
	{
		public HttpBudgetRepository(HttpClient httpClient) : base(httpClient)
		{
			//
		}

		public async Task<Budget> Get(int id)
		{
			Budget budget = null;
			try
			{
				budget = await httpClient.GetFromJsonAsync<Budget>("api/Budget/" + id, this.serializerOptions);
			}
			catch(Exception x)
			{
				x.ToString();
			}
			return budget;
		}

		public async Task<DbTaskResult> Save(Budget budget)
		{
			var resp = await httpClient.PutAsJsonAsync<Budget>("api/Budget", budget, this.serializerOptions);

			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}
	}
}
