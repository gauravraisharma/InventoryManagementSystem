//using IMS.Shared.Interface;
//using IMS.WebApp.Client.Services.Product;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http.Features;
using MudBlazor.Services;
//using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.Services.AddMudServices();
builder.Services.AddHttpClient();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44317/") });

//builder.Services.AddHttpClient("APIClient", client =>
//{
//    client.BaseAddress = new Uri("https://localhost:44317/");
//});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 50 * 1024 * 1024; // 50 MB
    
});

// Register HttpClient
builder.Services.AddMudServices();
await builder.Build().RunAsync();