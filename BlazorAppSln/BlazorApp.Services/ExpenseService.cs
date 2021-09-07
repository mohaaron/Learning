using BlazorApp.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
	public class ExpenseService : IExpenseService
	{
		private IExpenseRepository repository;

		public ExpenseService(IExpenseRepository repository)
		{
			this.repository = repository;
		}
	}
}
