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
using BlazorApp.Shared;

namespace BlazorApp.Client.Components.DialogWindows
{
    public partial class ExpenseForm
    {
        [Inject] private IHttpClientRepository<Expense> repository { get; set; }

        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter] public Expense Expense { get; set; } = new();

        [Parameter] public ICollection<Income> Paychecks { get; set; }

        private Expense validateExpense { get; set; } = new();

        private int paycheckId { get; set; } = 0;

        protected override Task OnInitializedAsync()
        {
            if (Expense is not null)
            {
                // Load validation entity for edit
                if (Expense.Income is not null)
                    paycheckId = Expense.Income.Id;

                //validateExpense = EntityHelper.Clone<Expense>(Expense);
                validateExpense = new Expense
                {
                    Cost = Expense.Cost,
                    DueDate = Expense.DueDate,
                    ExpenseName = Expense.ExpenseName,
                    Id = Expense.Id,
                    Notes = Expense.Notes
                };
			}

            return base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

        async Task Save()
        {
            if (paycheckId == 0)
            {
                validateExpense.Income = null;
            }
            else
                validateExpense.Income = Paychecks.Single(p => p.Id == paycheckId);
          
            await BlazoredModal.CloseAsync(ModalResult.Ok<Expense>(validateExpense));
        }

        async Task Cancel() => await BlazoredModal.CancelAsync();
    }
}