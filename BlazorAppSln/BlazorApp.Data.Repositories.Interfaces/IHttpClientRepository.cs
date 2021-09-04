using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Data.Repositories.Interfaces
{
	public interface IHttpClientRepository<T> : IDisposable
	{
		//Task<List<T>> GetPaged(int page, int pageSize);
		Task<T> Get(int id);
		Task<DbTaskResult> Create(T entity);
		Task<DbTaskResult> Update(int? id, T entity);
		Task<DbTaskResult> Delete(int id);
	}
}
