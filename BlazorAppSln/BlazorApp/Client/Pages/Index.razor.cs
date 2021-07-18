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
			budget = await repository.GetBudget(id);

			//return await base.OnInitializedAsync();
		}
	}
}
