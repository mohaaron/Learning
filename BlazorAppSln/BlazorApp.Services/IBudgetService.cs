using BlazorApp.Data.Models;

namespace BlazorApp.Services
{
	public interface IBudgetService
	{
		Task<Budget> Get(int id);
	}
}
