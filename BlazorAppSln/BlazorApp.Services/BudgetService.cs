﻿using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
	public class BudgetService : IBudgetService
	{
		private IBudgetRepository repository;

		public BudgetService(IBudgetRepository repository)
		{
			this.repository = repository;
		}

		public Task<Budget> Get(int id)
		{
			throw new NotImplementedException();
		}
	}
}
