namespace AdventOfCode
{
    internal interface ITask : IHasInput
    {
        public Task<int> ProcessPart1();
        public Task<int> ProcessPart2();
    }
}