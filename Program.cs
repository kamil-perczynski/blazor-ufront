using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using blazor_ufront;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// builder.RootComponents.Add<App>("#app");
// builder.RootComponents.Add<HeadOutlet>("head::after");

builder.RootComponents.RegisterForJavaScript<App>("blazor-ufront");

builder.Services.AddSingleton<StateContainer>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var app = builder.Build();

await app.RunAsync();



