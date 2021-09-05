using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpenseController : ControllerBase
	{
		private readonly IExpenseRepository repo;

		public ExpenseController(IExpenseRepository repo)
		{
			this.repo = repo;
		}

		// GET: api/<BudgetController>
		[HttpGet]
		public IEnumerable<string> Get(int pageNumber, int pageSize)
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/expense/5
		[HttpGet("{id}")]
		public async Task<Expense> Get(int id)
		{
			var entity = await repo.GetByIdAsync<Expense>(id);
			return entity;
		}

		// POST api/expense
		// Body: entity
		[HttpPost]
		public async Task<ActionResult<HttpStatusCode>> Post([FromBody] Expense entity)
		{
			if (entity == null)
				return BadRequest();

			var result = await repo.Save(entity); // Maybe repo.Get(id); updated expense with related items

			return result.StatusCode;
		}

		// PUT api/expense/
		[HttpPut]
		public async Task<ActionResult<HttpStatusCode>> Put([FromBody] Expense entity)
		{
			if (entity == null)
				return BadRequest();

			var result = await repo.Save(entity); // Maybe repo.Get(id); updated expense with related items

			return result.StatusCode;
		}

		// DELETE api/expense/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			repo.DeleteByIdAsync<Expense>(id);
		}
	}
}
