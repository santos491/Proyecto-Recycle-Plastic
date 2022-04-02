using Entities.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Recycle_Plastic_Blazor.Components.ProductTable
{
	public partial class EventsTable
    {
        [Parameter]
        public List<Events> events { get; set; }
        [Parameter]
        public EventCallback<Guid> OnDeleted { get; set; }
        [Inject] 
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }

        private void RedirectToUpdate(Guid id) 
        { 
            var url = Path.Combine("/updateEvent/", id.ToString()); 
            NavigationManager.NavigateTo(url); 
        }

        private async Task DeleteEvent(Guid id)
        {
            var eventss = events.FirstOrDefault(p => p.Id.Equals(id));
            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {eventss.Evento} event?");
            if (confirmed)
            {
                await OnDeleted.InvokeAsync(id);
            }
        }
    }
}
