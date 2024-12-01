namespace AdventOfCode
{
    internal interface IHasInput
    {
        public Task<string> GetInputStringFromUrl(string url);

        public void ExtractInput(string input);
    }
}