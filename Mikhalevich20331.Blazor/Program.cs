using Mikhalevich20331.Blazor.Components;
using Mikhalevich20331.Blazor.Services;
using Mikhalevich20331.ZooshopDomain.Entities;

namespace Mikhalevich20331.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents();


			builder.Services
			.AddHttpClient<IProductService<Product>, ApiProductService>(c =>
			c.BaseAddress = new Uri("https://localhost:7002/api/Products"));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error", createScopeForErrors: true);
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseAntiforgery();

			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode();

			app.Run();
		}
    }
}
