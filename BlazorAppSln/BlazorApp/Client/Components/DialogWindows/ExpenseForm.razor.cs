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

namespace BlazorApp.Client.Components.DialogWindows
{
    public partial class ExpenseForm
    {
        [CascadingParameter]
        BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public Expense expense { get; set; } = new();
        private Expense validate { get; set; } = new();

        public ICollection<Income> Paychecks { get; set; }

        protected override Task OnInitializedAsync()
        {
            if (expense is not null)
            {
                // Load validation entity for edit
                validate.Id = expense.Id;
                validate.ExpenseName = expense.ExpenseName;
                validate.Cost = expense.Cost;
                validate.Notes = expense.Notes;

				Paychecks = expense.Budget.Incomes;
			}

            return base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

        async Task Save()
        {
            expense.Id = validate.Id;
            expense.ExpenseName = validate.ExpenseName;
            expense.Cost = validate.Cost;
            expense.Notes = validate.Notes;
            await BlazoredModal.CloseAsync(ModalResult.Ok<Expense>(expense));
        }

        async Task Cancel() => await BlazoredModal.CancelAsync();
    }
}