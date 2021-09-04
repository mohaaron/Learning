using BlazorApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Data.Repositories.Interfaces
{
	public interface IIncomeRepository : IRepositoryBaseAsync
	{
		Task<Income> Get(int id);
		Task<DbTaskResult> Save(Income entity);
	}
}
