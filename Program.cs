using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tienda.Servicios;
using Tienda;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<CarritoService>();
builder.RootComponents.Add<App>("#app");

await builder.Build().RunAsync();
