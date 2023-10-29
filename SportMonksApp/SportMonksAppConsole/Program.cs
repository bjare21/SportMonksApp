using ApiRequesterLibrary;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Newtonsoft.Json;
using SportMonksAppConsole;
using Microsoft.Extensions.Configuration;


var services = ConfigureServices();
var serviceProvider = services.BuildServiceProvider();
await serviceProvider.GetService<SportMonksConsole>().RunAsync();


static IServiceCollection ConfigureServices()
{
    IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(@"D:\C# Projekty\_Moje\SportMonksApp\SportMonksApp\SportMonksAppConsole\appSettings.json", false)
        .Build();

    IServiceCollection services = new ServiceCollection();
    services.AddTransient<SportMonksConsole>();
    services.AddHttpClient<ApiRequesterClient>(x => x.BaseAddress = new Uri(SportMonksAppConstants.ApiBaseUrl));
    services.AddSingleton<JsonSerializer>();
    services.AddSingleton<IConfiguration>(configuration);

    return services;
}
