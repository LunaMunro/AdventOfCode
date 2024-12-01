using Microsoft.Extensions.Configuration;

namespace AdventOfCode
{
    internal abstract class TaskBase : ITask
    {
        private string GetUserSession()
        {
            IConfiguration configuration = (IConfiguration)new ConfigurationManager().
                AddUserSecrets<Program>();

            string sessionToken = configuration["AdventSessionToken"];
            if (string.IsNullOrEmpty(sessionToken))
            {
                throw new ArgumentException("AdventOfCode token not found on machine!");
            }
            return sessionToken;
        }

        public async Task GetInput(string url)
        {
            string sessionToken = this.GetUserSession();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "AdventOfCode");
                client.DefaultRequestHeaders.Add("Cookie", $"session={sessionToken}");
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    this.ParseInput(response.Content.ReadAsStringAsync());
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public abstract void ParseInput(Task<string> input);

        public abstract Task<int> ProcessPart1();

        public abstract Task<int> ProcessPart2();
    }
}