using Recycle_Plastic_Blazor.Features;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recycle_Plastic_Blazor.HttpRepository
{
    public interface IEventHttpRepository
    {
        Task<PagingResponse<Events>> GetEvents(EventsParameters eventsParameters);
        Task CreateEvent(Events events);
        Task<Events> GetEvent(string id);
        Task UpdateEvent(Events events);
        Task DeleteEvent(Guid id);
    }
}
