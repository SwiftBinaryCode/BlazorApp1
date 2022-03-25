global using BlazorApp1.Client.Services.SuperCourseService;
global using BlazorApp1.Client.Services.SuperStudentService;
global using BlazorApp1.Shared;

using BlazorApp1.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISuperCourseService, SuperCourseService>();
await builder.Build().RunAsync();
