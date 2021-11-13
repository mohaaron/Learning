using BlazorApp.Data.Models;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
	public interface IBudgetService
	{
		Task<Budget> Get(int id);
	}
}
