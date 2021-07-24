﻿using BlazorApp.Data.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Data.Repositories.Interfaces
{
	public interface IBudgetRepository
	{
		Task<Budget> Get(int id);
		Task<DbTaskResult> Save(Budget budget);
	}
}
