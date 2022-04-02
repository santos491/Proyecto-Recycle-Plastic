using Blazored.LocalStorage;
using Recycle_Plastic_Blazor.AuthProviders;
using Recycle_Plastic_Blazor.HttpRepository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recycle_Plastic_Blazor
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5011/api/") });
			builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();
			builder.Services.AddScoped<IEventHttpRepository, EventHttpRepository>();
			builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
			builder.Services.AddBlazoredLocalStorage(); 
			builder.Services.AddAuthorizationCore(); 
			builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

			await builder.Build().RunAsync();
		}
	}
}
