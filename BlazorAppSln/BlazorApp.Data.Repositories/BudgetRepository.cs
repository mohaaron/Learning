using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
			try
			{
				return await context.Budget
				.Include(e => e.Expenses)
					//.ThenInclude(e => e.Budget) // Not needed to have a reference to Expense.Budget
				.Include(i => i.Incomes)
					.ThenInclude(i => i.Expenses) // This works
				.SingleAsync(b => b.Id == id);
			}
			catch(Exception x)
			{
				x.ToString();
			}

			return null;
		}

		public async Task<DbTaskResult> SaveBudget(Budget budget)
		{
			var result = new DbTaskResult();
			await Task.CompletedTask;

			context.Update(budget);
			try
			{
				//await context.SaveChangesAsync();
				result.StatusCode = HttpStatusCode.OK;
			}
			catch(Exception x)
			{
				result.StatusCode = HttpStatusCode.InternalServerError;
				result.Message = x.Message;
			}

			return result;
		}
	}
}
