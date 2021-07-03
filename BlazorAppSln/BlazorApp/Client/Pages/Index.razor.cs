using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages
{
	public partial class Index
	{
		[Inject] private IBudgetRepository repository { get; set; }

		private Budget budget;

        protected override async Task OnInitializedAsync()
        {
            int id = 20216;
			// TODO: Create method GetLatestBudget()
            budget = await repository.GetBudget(id);

            //return await base.OnInitializedAsync();
        }

		private async Task AddExpenseClick(Expense expense)
		{
			//budget.Expenses.Add(expense);
			//var result = await repo.AddExpense(expense);
			//if (result.StatusCode == HttpStatusCode.OK)
			//{
			//	// Saved, now add saved expense to budget to update UI
			//	budget.Expenses.Add(expense);
			//}

			await Task.FromResult("");
		}

		private async Task EditExpenseClick(Expense expense)
		{
			//var result = await repo.SaveBudget(expense);
			//if (result.StatusCode == HttpStatusCode.OK)
			//{
			//	// Saved, now add saved expense to budget to update UI
			//	budget.Expenses.Add(expense);
			//}

			await Task.FromResult("");
		}
	}
}
