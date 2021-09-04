using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Pages
{
	public partial class Index
	{
		[Inject] private IHttpClientRepository<Budget> repository { get; set; }

		private Budget budget;

        protected override async Task OnInitializedAsync()
        {
            int id = 20216;
			budget = await repository.Get(id);

			//return await base.OnInitializedAsync();
		}
	}
}
