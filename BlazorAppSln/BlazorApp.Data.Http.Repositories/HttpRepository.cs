using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp.Data.Http.Repositories
{
	public class HttpRepository : HttpRepositoryBase//, IRepositoryBaseAsync
    {
		public HttpRepository(HttpClient httpClient) : base(httpClient)
		{
		}

        //public Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        //{
        //	throw new NotImplementedException();
        //}

        //public Task<int> DeleteByIdAsync<TEntity>(int id) where TEntity : class
        //{
        //	throw new NotImplementedException();
        //}

        //public Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        //{
        //	throw new NotImplementedException("Using a predicate from here doesn't make sense.");
        //}

        //public Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "") where TEntity : class
        //{
        //	throw new NotImplementedException("Using a predicate from here doesn't make sense.");
        //}

        public async Task<Expense> Get(int id)
        {
            var response = await httpClient.GetAsync("api/expense/" + id);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var entity = JsonSerializer.Deserialize<Expense>(content, this.serializerOptions);
            return entity;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class
		{
			var httpContent = await httpClient.GetAsync("api/budget/" + id);
			string jsonContent = httpContent.Content.ReadAsStringAsync().Result;
			TEntity obj = JsonSerializer.Deserialize<TEntity>(jsonContent);
			return obj;
		}

		public async Task<T> GetJsonAsync<T>(int id)
        {
            var httpContent = await httpClient.GetAsync("api/budget/" + id);
            string jsonContent = httpContent.Content.ReadAsStringAsync().Result;
            T obj = JsonSerializer.Deserialize<T>(jsonContent);
            httpContent.Dispose();
            
            return obj;
        }
        public async Task<HttpResponseMessage> PostJsonAsync<T>(string requestUri, T content)
        {
            string myContent = JsonSerializer.Serialize(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(requestUri, stringContent);
            
            return response;
        }
        public async Task<HttpResponseMessage> PutJsonAsync<T>(string requestUri, T content)
        {
            string myContent = JsonSerializer.Serialize(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(requestUri, stringContent);
            
            return response;
        }

		public Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
		{
			throw new NotImplementedException();
		}
	}
}
