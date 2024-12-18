using Blazored.LocalStorage;
using IMS.Shared.Interface.Auth;
using IMS.Shared.Interface.Cart;
using IMS.Shared.Interface.Category;
using IMS.Shared.Interface.Department;
using IMS.Shared.Interface.Product;
using IMS.Shared.Services.Auth;
using IMS.Shared.Services.Cart;
using IMS.Shared.Services.Shared;
using IMS.WebApp.Client.Authentication;
using IMS.WebApp.Client.Pages;
using IMS.WebApp.Client.Services.Category;
using IMS.WebApp.Client.Services.Department;
using IMS.WebApp.Client.Services.Product;
using IMS.WebApp.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateService>();
builder.Services.AddScoped<AuthStateService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddSingleton<CartStateService>();

builder.Services.AddMudServices();
//builder.Services.AddMudServices(config =>
//{
//    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
//    config.SnackbarConfiguration.PreventDuplicates = false;
//    config.SnackbarConfiguration.NewestOnTop = false;
//    config.SnackbarConfiguration.ShowCloseIcon = true;
//    config.SnackbarConfiguration.VisibleStateDuration = 10000;
//    config.SnackbarConfiguration.HideTransitionDuration = 500;
//    config.SnackbarConfiguration.ShowTransitionDuration = 500;
//    config.PopoverOptions.ThrowOnDuplicateProvider = false;
//});
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => options.DetailedErrors = true);

builder.Services.AddHttpClient("APIClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:44317/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(IMS.WebApp.Client._Imports).Assembly);


app.Run();
