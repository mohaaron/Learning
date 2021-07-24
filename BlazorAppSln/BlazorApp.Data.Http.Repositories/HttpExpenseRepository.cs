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
	public class HttpExpenseRepository : IExpenseRepository
	{
		private readonly HttpClient httpClient;
		private readonly JsonSerializerOptions serializerOptions;

		public HttpExpenseRepository(HttpClient httpClient)
		{
			this.httpClient = httpClient;
			this.serializerOptions = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.Preserve };
		}

		public async Task<Expense> Get(int id)
		{
			Expense entity = null;
			try
			{
				entity = await httpClient.GetFromJsonAsync<Expense>("api/Expense/" + id, this.serializerOptions);
			}
			catch(Exception x)
			{
				x.ToString();
			}
			return entity;
		}

		public async Task<DbTaskResult> Save(Expense entity)
		{
			HttpResponseMessage resp;
			if (entity.Id == 0)
				resp = await httpClient.PostAsJsonAsync<Expense>("api/Expense", entity, this.serializerOptions);
			else
				resp = await httpClient.PutAsJsonAsync<Expense>("api/Expense", entity, this.serializerOptions);

			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}
	}
}
