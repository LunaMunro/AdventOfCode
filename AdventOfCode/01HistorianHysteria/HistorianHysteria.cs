namespace AdventOfCode.HystorianHysteria
{
    internal class HystorianHysteria(string url) : TaskBase
    {
        private IEnumerable<(int, int)>? Data;
        private readonly string Url = url;

        public override async Task<int> ProcessPart1()
        {
            await this.GetInput(this.Url);

            int runningDistanceTotal = 0;
            int[] column1 = this.Data.Select(i => i.Item1).Order().ToArray(),
                  column2 = this.Data.Select(i => i.Item2).Order().ToArray();

            for (int i = 0; i < this.Data.Count(); i++)
            {
                runningDistanceTotal += Math.Abs(column2[i] - column1[i]);
            }
            return runningDistanceTotal;
        }

        public override async Task<int> ProcessPart2()
        {
            await this.GetInput(this.Url);

            int runningSimilarityScore = 0;
            for (int i = 0; i < this.Data.Count(); i++)
            {
                int currInt = this.Data.ElementAt(i).Item1;
                int matches = this.Data.Where(d => d.Item2 == currInt).Count();
                runningSimilarityScore += matches * currInt;
            }
            return runningSimilarityScore;
        }

        public override async void ParseInput(Task<string> input)
        {
            string stringInput = await input;
            var lines = stringInput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var data = new List<(int, int)>();

            foreach (var line in lines)
            {
                var numbers = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();

                if (numbers.Length == 2)
                {
                    data.Add((numbers[0], numbers[1]));
                }
            }
            this.Data = data;
        }
    }
}
