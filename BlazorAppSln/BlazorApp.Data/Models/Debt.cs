﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Data.Models
{
	public class Debt
	{
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// The name of the company managing the debt.
		/// </summary>
		[Required]
		[StringLength(200)]
		public string CompanyName { get; set; }

		/// <summary>
		/// The type of debt. Ex. Credit, Mortgage, ...
		/// </summary>
		[Required]
		[StringLength(20)]
		public string DebtType { get; set; }

		/// <summary>
		/// The full amount of debt owed.
		/// </summary>
		public decimal Amount { get; set; }
	}
}
