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
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter] public Expense Expense { get; set; } = new();

        [Parameter] public ICollection<Income> Paychecks { get; set; }

        private Expense validate { get; set; } = new();

        protected override Task OnInitializedAsync()
        {
            if (Expense is not null)
            {
                // Load validation entity for edit
                validate.Id = Expense.Id;
                validate.ExpenseName = Expense.ExpenseName;
                validate.Cost = Expense.Cost;
                validate.Notes = Expense.Notes;
			}
            else
			{
                // Get paychecks from ???
			}

            return base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            // What do we use this for?

            return base.OnParametersSetAsync();
        }

        async Task Save()
        {
            Expense.Id = validate.Id;
            Expense.ExpenseName = validate.ExpenseName;
            Expense.Cost = validate.Cost;
            Expense.Notes = validate.Notes;
            await BlazoredModal.CloseAsync(ModalResult.Ok<Expense>(Expense));
        }

        async Task Cancel() => await BlazoredModal.CancelAsync();
    }
}