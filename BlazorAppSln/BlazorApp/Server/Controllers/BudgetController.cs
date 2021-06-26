using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BudgetController : ControllerBase
	{
		private readonly IBudgetRepository repo;

		public BudgetController(IBudgetRepository repo)
		{
			this.repo = repo;
		}

		// GET: api/<BudgetController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<BudgetController>/5
		[HttpGet("{id}")]
		public async Task<Budget> Get(int id)
		{
			Budget budget = await repo.GetBudget(id);
			return budget;
		}

		// POST api/<BudgetController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<BudgetController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<BudgetController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
