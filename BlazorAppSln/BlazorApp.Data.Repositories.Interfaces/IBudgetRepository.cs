using BlazorApp.Data.Models;
using System.Threading.Tasks;

namespace BlazorApp.Data.Repositories.Interfaces
{
	public interface IBudgetRepository : IAsyncRepository
	{
		Task<Budget> GetBudget(int id);
	}
}
