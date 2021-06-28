using BlazorApp.Data.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Data.Repositories.Interfaces
{
	public interface IBudgetRepository
	{
		Task<Budget> GetBudget(int id);
		Task<DbTaskResult> SaveBudget(Budget budget);
	}
}
