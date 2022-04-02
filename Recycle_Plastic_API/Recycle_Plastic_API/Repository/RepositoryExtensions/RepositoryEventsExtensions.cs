using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Recycle_Plastic_API.Repository.RepositoryExtensions
{
    public static class RepositoryEventsExtensions
    {
        public static IQueryable<Events> Search(this IQueryable<Events> events, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return events;

            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();

            return events.Where(p => p.Evento.ToLower().Contains(lowerCaseSearchTerm));
        }

        /*public static IQueryable<Product> Sort(this IQueryable<Product> products, string orderByQueryString) 
        { 
            if (string.IsNullOrWhiteSpace(orderByQueryString)) 
                return products.OrderBy(e => e.Name); 
            
            var orderParams = orderByQueryString.Trim().Split(','); 
            var propertyInfos = typeof(Product).GetProperties(BindingFlags.Public | BindingFlags.Instance); 
            var orderQueryBuilder = new StringBuilder(); 
            
            foreach (var param in orderParams) 
            { 
                if (string.IsNullOrWhiteSpace(param)) 
                    continue; 
                
                var propertyFromQueryName = param.Split(" ")[0]; 
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase)); 
                
                if (objectProperty == null) 
                    continue; 
                
                var direction = param.EndsWith(" desc") ? "descending" : "ascending"; 
                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, "); 
            } 
            
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' '); 
            if (string.IsNullOrWhiteSpace(orderQuery)) 
                return products.OrderBy(e => e.Name); 
            
            return products.OrderBy(orderQuery); 
        }*/
    }
}
