using Recycle_Plastic_Blazor.Features;
using Entities.Models;
using Entities.RequestFeatures;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Recycle_Plastic_Blazor.HttpRepository
{
    public class EventHttpRepository : IEventHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public EventHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<PagingResponse<Events>> GetEvents(EventsParameters eventsParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = eventsParameters.PageNumber.ToString(),
                ["searchTerm"] = eventsParameters.SearchTerm == null ? "" : eventsParameters.SearchTerm,
                ["orderBy"] = eventsParameters.OrderBy
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString("events", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Events>
            {
                Items = JsonSerializer.Deserialize<List<Events>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };

            return pagingResponse;
        }

        public async Task CreateEvent(Events events) 
        { 
            var content = JsonSerializer.Serialize(events); 
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json"); 

            var postResult = await _client.PostAsync("events", bodyContent); 
            var postContent = await postResult.Content.ReadAsStringAsync(); 

            if (!postResult.IsSuccessStatusCode) 
            { 
                throw new ApplicationException(postContent); 
            } 
        }

       

        public async Task<Events> GetEvent(string id)
        {
            var url = Path.Combine("events", id);

            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var events = JsonSerializer.Deserialize<Events>(content, _options);
            return events;
        }

        public async Task UpdateEvent(Events events)
        {
            var content = JsonSerializer.Serialize(events);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("events", events.Id.ToString());

            var postResult = await _client.PutAsync(url, bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task DeleteEvent(Guid id)
        {
            var url = Path.Combine("events", id.ToString());

            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();

            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }
    }
}
