﻿using BlazorApp.Data.Models;
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
	public class ExpenseRepository : RepositoryAsyncBase<BudgetContext>, IExpenseRepository
	{
		public ExpenseRepository(BudgetContext context) : base(context)
		{
			//
		}

		public async Task<Expense> Get(int id)
		{
			try
			{
				return await this.GetByIdAsync<Expense>(id);
			}
			catch(Exception x)
			{
				x.ToString();
			}

			return null;
		}

		public async Task<DbTaskResult> Save(Expense entity)
		{
			var result = new DbTaskResult();
			await Task.CompletedTask;

			context.Update(entity);
			try
			{
				await context.SaveChangesAsync();
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
