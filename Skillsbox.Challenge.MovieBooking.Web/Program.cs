using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Skillsbox.Challenge.MovieBooking.Web;
using Skillsbox.Challenge.MovieBooking.Web.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var connectionUri = builder.Configuration.GetValue<string>("BaseAPIUrl");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(connectionUri) });
builder.Services.AddScoped<ICategoryService, CategoryService>();

await builder.Build().RunAsync();
