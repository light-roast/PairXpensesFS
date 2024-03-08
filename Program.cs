global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PairXpensesFS;
using PairXpensesFS.Services;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DebtService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddHttpClient<UserService>(client =>
{
    client.BaseAddress = new("http://localhost:5002");
});
builder.Services.AddHttpClient<DebtService>(client =>
{
    client.BaseAddress = new("http://localhost:5002");
});
builder.Services.AddHttpClient<PaymentService>(client =>
{
    client.BaseAddress = new("http://localhost:5002");
});
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient();
builder.Services.AddOidcAuthentication(options =>
{
	// Configure your authentication provider options here.
	// For more information, see https://aka.ms/blazor-standalone-auth
	builder.Configuration.Bind("Local", options.ProviderOptions);
});

await builder.Build().RunAsync();
