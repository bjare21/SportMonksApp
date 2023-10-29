using ApiRequesterLibrary;
using Microsoft.Extensions.Configuration;
using SportMonksAppConsole.Data;

namespace SportMonksAppConsole
{
    public class SportMonksConsole
    {
        private readonly ApiRequesterClient client;
        private readonly IConfiguration configuration;

        public SportMonksConsole(ApiRequesterClient client, IConfiguration configuration)
        {
            this.client = client;
            this.configuration = configuration;
        }
        public async Task RunAsync()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken cancellationToken = cts.Token;

            var fixturesData = await client.GetListAsync<Fixture>($"{SportMonksAppConstants.GetAllFixtures}?api_token={getToken()}", cancellationToken);
            Console.WriteLine(".");
        }

        private string getToken()
        {
            string token = configuration.GetSection("apiToken").Value;
            return token;
        }
    }
}