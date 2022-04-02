using Recycle_Plastic_Blazor.HttpRepository;
using Recycle_Plastic_Blazor.Shared;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recycle_Plastic_Blazor.Pages
{
    public partial class CreateEvent
    {
        private Events Events = new Events();
		private SuccessNotification _notification;

		[Inject]
        public IEventHttpRepository EventRepo { get; set; }

        /*private async Task CreateEvents()
        {
            //await EventRepo.CreateEvent(Events);
			_notification.Show();
		}*/
    }
}
