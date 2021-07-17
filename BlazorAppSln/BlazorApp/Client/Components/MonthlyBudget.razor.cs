using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using Blazored.Modal;
using Blazored.Modal.Services;
using BlazorApp.Client;
using BlazorApp.Client.Shared;
using BlazorApp.Data.Models;
using BlazorApp.UI.Library;
using BlazorApp.Data.Repositories.Interfaces;
using BlazorApp.Client.Components.DialogWindows;

namespace BlazorApp.Client.Components
{
    public partial class MonthlyBudget
    {
        [Inject] private IBudgetRepository repository { get; set; }

        [Parameter] public Budget Budget { get; set; }

        [Parameter] public EventCallback<Expense> AddExpenseCallback { get; set; }

        [Parameter] public EventCallback<Expense> EditExpenseCallback { get; set; }

        [Parameter] public EventCallback<HashSet<int>> DeleteExpenseCallback { get; set; }

        [CascadingParameter] public IModalService Modal { get; set; }

        private string title { get; set; }

        protected override Task OnInitializedAsync()
        {
            title = Budget.Id.ToString().Insert(4, "-");

            foreach(Expense expense in Budget.Expenses)
			{
                if (expense.Budget is not null)
				{
                    ICollection<Income> paychecks = expense.Budget.Incomes; // How do I populate budget?
                }
			}

   //         foreach (Income income in Budget.Incomes)
   //         {
			//	foreach(Expense expense in income.Expenses)
			//	{
   //                 int id = expense.Id;
			//	}                    
			//}

            return base.OnInitializedAsync();
        }

        async Task AddExpense()
        {
			IModalReference modal = Modal.Show<ExpenseForm>("Add Expense");
            var win = await modal.Result;
            if (!win.Cancelled)
            {
				Expense expense = (Expense)win.Data;
                await AddExpenseCallback.InvokeAsync(expense); // Send expense object to subscribers
                var db = await repository.SaveBudget(Budget);
                if (db.StatusCode == HttpStatusCode.OK)
                {
                    // Saved, now add saved expense to budget to update UI
                    Budget.Expenses.Add(expense);
                }
            }
        }

        async Task EditExpense(Expense expense)
        {
			ModalParameters parameters = new ModalParameters();
            parameters.Add("Expense", expense);
            var form = Modal.Show<ExpenseForm>("Edit Expense", parameters);
            var result = await form.Result;
            if (!result.Cancelled)
            {
                await EditExpenseCallback.InvokeAsync(expense); // Send expense object to subscribers
            }
        }

        HashSet<int> expensesToDelete = new HashSet<int>();

		void ExpenseCheckChanged(ChangeEventArgs e, int id)
        {
            if (expensesToDelete.Contains(id))
                expensesToDelete.Remove(id);
            else
                expensesToDelete.Add(id);
        }

        async Task DeleteExpense()
        {
            if (expensesToDelete.Count > 0)
            {
                foreach (int id in expensesToDelete)
                {
                    var expense = Budget.Expenses.SingleOrDefault(e => e.Id == id);
                    Budget.Expenses.Remove(expense);
                }

                await DeleteExpenseCallback.InvokeAsync(expensesToDelete);
            }
        }
    }
}