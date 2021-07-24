using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.UI.Library
{
	public partial class Component1 : ComponentBase
	{
		[Parameter]
		public string Name { get; set; } = "Aaron Prohaska";
	}
}
