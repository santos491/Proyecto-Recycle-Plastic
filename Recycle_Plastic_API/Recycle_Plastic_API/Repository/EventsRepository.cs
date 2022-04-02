using Recycle_Plastic_API.Context;
using Recycle_Plastic_API.Paging;
using Recycle_Plastic_API.Repository.RepositoryExtensions;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Recycle_Plastic_API.Repository
{
    public class EventsRepository :IEventsRepository
    {
        private readonly ProductContext _context;

        public EventsRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Events>> GetEvents(EventsParameters eventsParameters)
        {
            var eventos = await _context.events
                .Search(eventsParameters.SearchTerm)
                //.Sort(productParameters.OrderBy)
                .ToListAsync();

            return PagedList<Events>
                .ToPagedList(eventos, eventsParameters.PageNumber, eventsParameters.PageSize);
        }

        public async Task CreateEvent(Events events)
        {
            _context.Add(events);
            await _context.SaveChangesAsync();
        }

        public async Task<Events> GetEvent(int id) => 
            await _context.events.FirstOrDefaultAsync(p => p.Id.Equals(id));

        public async Task UpdateEvent(Events events, Events dbEvent)
        {
            dbEvent.Evento = events.Evento;
            dbEvent.Lugar = events.Lugar;
            dbEvent.Organizador = events.Organizador;
            dbEvent.Contacto = events.Contacto;
            dbEvent.Fecha = events.Fecha;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEvent(Events events)
        {
            _context.Remove(events);
            await _context.SaveChangesAsync();
        }
    }
}
