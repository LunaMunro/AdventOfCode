using Microsoft.Extensions.Configuration;

namespace AdventOfCode
{
    internal abstract class ChallengeBase : IChallenge, IHasInput
    {
        private string GetUserSession()
        {
            IConfiguration configuration = (IConfiguration)new ConfigurationManager().
                AddUserSecrets<Program>();

            string? sessionToken = configuration["AdventSessionToken"];
            if (string.IsNullOrEmpty(sessionToken))
            {
                throw new ArgumentException("AdventOfCode token not found on machine!");
            }
            return sessionToken;
        }

        public async Task<string> GetInputStringFromUrl(string url)
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

                    return await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public abstract void ExtractInput(string input);

        public abstract int ProcessPart1();

        public abstract int ProcessPart2();
    }
}