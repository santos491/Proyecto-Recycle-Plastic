using Recycle_Plastic_Blazor.HttpRepository;
using Entities.Models;
using Entities.RequestFeatures;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recycle_Plastic_Blazor.Pages
{
    public partial class Events
    {
        public List<Events> EventLists { get; set; } = new List<Events>();
        public MetaData MetaData { get; set; } = new MetaData();

        private EventsParameters _eventsParameters = new EventsParameters();

        [Inject]
        public IEventHttpRepository EventRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetEvents();
        }

        private async Task SelectedPage(int page)
        {
            _eventsParameters.PageNumber = page;
            await GetEvents();
        }

        private async Task GetEvents()
        {
            var pagingResponse = await EventRepo.GetEvents(_eventsParameters);
            //EventLists = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }

        private async Task SearchChanged(string searchTerm)
        {
            Console.WriteLine(searchTerm);
            _eventsParameters.PageNumber = 1;
            _eventsParameters.SearchTerm = searchTerm;
            await GetEvents();
        }

        private async Task SortChanged(string orderBy)
        {
            Console.WriteLine(orderBy);
            _eventsParameters.OrderBy = orderBy;
            await GetEvents();
        }

        private async Task DeleteEvent(Guid id)
        {
            await EventRepo.DeleteEvent(id);
            _eventsParameters.PageNumber = 1;
            await GetEvents();
        }
    }
}
