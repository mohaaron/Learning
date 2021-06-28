using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
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
		public async Task<ActionResult<Budget>> Put([FromBody] Budget budget)
		{
			if (budget == null)
				return BadRequest();

			await repo.SaveBudget(budget);

			return Ok(budget);
		}

		// DELETE api/<BudgetController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
