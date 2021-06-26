using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Data.Repositories
{
	public class BudgetRepository : AsyncRepositoryBase<BudgetContext>, IBudgetRepository
	{
		private readonly BudgetContext context;

		public BudgetRepository(BudgetContext context) : base(context)
		{
			this.context = context;
		}

		public async Task<Budget> GetBudget(int id)
		{
			return await context.Budget
				.Include(e => e.Expenses)
				.Include(i => i.Incomes)
				.SingleAsync(b => b.YearMonth == id);
		}
	}
}
