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

        [CascadingParameter] public IModalService Modal { get; set; }

        private string title { get; set; }

        protected override Task OnInitializedAsync()
        {
            //DateOnly date = DateOnly.FromDateTime(StartDate);
            //int id = 20216;
            //var Budget = await repository.GetBudget(id);

            title = Budget.Id.ToString().Insert(4, "-");

			return base.OnInitializedAsync();
		}

        async Task AddExpense()
        {
            ModalParameters parameters = new ModalParameters();
            parameters.Add("Paychecks", Budget.Incomes);

            IModalReference modal = Modal.Show<ExpenseForm>("Add Expense", parameters);
            var win = await modal.Result;

            if (!win.Cancelled)
            {
				Expense expense = (Expense)win.Data;

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
            parameters.Add("Paychecks", Budget.Incomes);

            var form = Modal.Show<ExpenseForm>("Edit Expense", parameters);
            var win = await form.Result;

            if (!win.Cancelled)
            {
                //
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
            }
        }
    }
}