using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp.Data.Http.Repositories
{
	public class HttpRepository<T> : HttpClient, IHttpClientRepository<T> where T : class
    {
		private string basePath;
		internal readonly JsonSerializerOptions serializerOptions;
		private const string MEDIA_TYPE = "application/json";
		private bool disposedValue;

		public HttpRepository(string baseAddress, string basePath)
		{
			BaseAddress = new Uri(baseAddress);
			this.basePath = basePath;
			this.serializerOptions = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.Preserve };
		}

		public async Task<DbTaskResult> Create(T entity)
		{
			HttpResponseMessage resp = await this.PostAsJsonAsync<T>(this.basePath, entity, this.serializerOptions);

			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}

		public async Task<DbTaskResult> Delete(int id)
		{
			HttpResponseMessage resp = await this.DeleteAsync(this.basePath + $"/{id}");

			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}

		public async Task<T> Get(int id)
		{
			try
			{
				return await this.GetFromJsonAsync<T>(this.basePath + $"/{id}", this.serializerOptions);
			}
			catch (Exception x)
			{
				x.ToString();
			}

			return null;
		}

		public async Task<DbTaskResult> Update(T entity)
		{
			HttpResponseMessage resp = await this.PutAsJsonAsync<T>(this.basePath, entity, this.serializerOptions);

			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}
	}
}
