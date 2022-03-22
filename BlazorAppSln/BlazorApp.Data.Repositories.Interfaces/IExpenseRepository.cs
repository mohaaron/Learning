using BlazorApp.Data.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Data.Repositories.Interfaces
{
	public interface IExpenseRepository : IRepositoryBaseAsync
	{
		//Task<DbTaskResult> Save(Expense entity);
	}
}
