using Recycle_Plastic_API.Paging;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Threading.Tasks;

namespace Recycle_Plastic_API.Repository
{
    public interface IEventsRepository
    {
        Task<PagedList<Events>> GetEvents(EventsParameters eventsParameters);
        Task CreateEvent(Events events);
        Task<Events> GetEvent(int id);
        Task UpdateEvent(Events events, Events dbEvent);
        Task DeleteEvent(Events events);
    }
}
