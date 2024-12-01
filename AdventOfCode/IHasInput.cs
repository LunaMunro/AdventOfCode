namespace AdventOfCode
{
    internal interface IHasInput
    {
        public Task GetInput(string url);

        public void ParseInput(Task<string> input);
    }
}