using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AdquisicionesADRES.BlazorClient;
using MudBlazor.Services;
using AdquisicionesADRES.BlazorClient.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<ProveedorApiClient>();
builder.Services.AddScoped<TipoAdquisicionApiClient>();
builder.Services.AddScoped<UnidadResponsableApiClient>();
builder.Services.AddScoped<EstadoAdquisicionApiClient>();
builder.Services.AddScoped<AdquisicionApiClient>();
builder.Services.AddScoped<ModuloApiClient>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7056/api/") });

await builder.Build().RunAsync();
