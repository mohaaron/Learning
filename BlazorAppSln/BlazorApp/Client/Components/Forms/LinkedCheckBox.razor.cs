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

namespace BlazorApp.Client.Components.Forms
{
    public partial class LinkedCheckBox
    {
        [CascadingParameter] public List<LinkedCheckBox> LinkedCheckBoxes { get; set; }
        [Parameter] public Action OnChange { get; set; }
		//[Parameter] public bool Checked { get; set; }

		protected override Task OnInitializedAsync()
        {
            //if (CheckedBoxes.Contains(this))
            //{
            //    CheckedBoxes.Remove(this);
            //}
            //else
            //{
            //    CheckedBoxes.Add(this);
            //}

            return base.OnInitializedAsync();
        }

        private bool _Checked = false;
        public bool Checked
        {

            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
				OnChange.Invoke();
			}

        }

  //      async void CheckChanged(MouseEventArgs e, LinkedCheckBox cbx)
		//{
  //          if (Checked)
		//	{
  //              foreach(var box in LinkedCheckboxes)
		//		{
  //                  box.Checked = true;
		//		}
		//	}
  //          await Task.FromResult("");
		//}
    }
}