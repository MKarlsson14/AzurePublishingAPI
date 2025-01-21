using BlazorAzurePublishing.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorAzurePublishing
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped<IAPIService, APIService>();

            builder.Services.AddHttpClient("CustomClient", client =>
            {
                client.BaseAddress = new Uri("https://azurepublishingapi.livelyrock-c9569136.swedencentral.azurecontainerapps.io/");
            });

            await builder.Build().RunAsync();
        }
    }
}
