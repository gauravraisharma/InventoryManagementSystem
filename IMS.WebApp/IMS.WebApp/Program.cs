using Blazored.LocalStorage;
using Blazored.SessionStorage;
using IMS.Shared.Interface.Address;
using IMS.Shared.Interface.Auth;
using IMS.Shared.Interface.Cart;
using IMS.Shared.Interface.Category;
using IMS.Shared.Interface.Code;
using IMS.Shared.Interface.Department;
using IMS.Shared.Interface.Order;
using IMS.Shared.Interface.Product;
using IMS.Shared.Services.Address;
using IMS.Shared.Services.Auth;
using IMS.Shared.Services.Cart;
using IMS.Shared.Services.Category;
using IMS.Shared.Services.code;
using IMS.Shared.Services.Department;
using IMS.Shared.Services.Order;
using IMS.Shared.Services.Product;
using IMS.Shared.Services.Shared;
//using IMS.Shared.Services.Order;
using IMS.WebApp.Client.Authentication;
using IMS.WebApp.Components;
using Microsoft.AspNetCore.Components.Authorization;
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
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateService>();
builder.Services.AddScoped<AuthStateService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ITwoFactorService, TwoFactorService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSingleton<CartStateService>();



builder.Services.AddMudServices();

var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
if (string.IsNullOrEmpty(apiBaseUrl))
{
    throw new Exception("ApiBaseUrl is not configured in appsettings.json");
}

// Initialize the ApiEndpoints with the Base URL
IMS.Shared.Constants.ApiEndpoints.Initialize(apiBaseUrl);
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

//builder.Services.AddHttpClient("APIClient", client =>
//{
//    client.BaseAddress = new Uri("https://localhost:44317/");
//});

builder.Services.AddHttpClient();

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
