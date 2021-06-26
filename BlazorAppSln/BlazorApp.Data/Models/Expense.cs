using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Data.Models
{
	public class Expense
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(400)]
		public string ExpenseName { get; set; }

		[Required]
		public decimal Cost { get; set; }

		public string Notes { get; set; }

		public DateTime? DueDate { get; set; }
	}
}
