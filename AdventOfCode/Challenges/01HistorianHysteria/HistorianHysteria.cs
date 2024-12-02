using System;

namespace AdventOfCode.Challenges.HistorianHysteria
{
    internal class HistorianHysteria : ChallengeBase
    {
        private static readonly string Url = "https://adventofcode.com/2024/day/1/input";

        private IEnumerable<(int, int)> Data;

        private HistorianHysteria() { } // Private constructor to enforce factory method usage

        public static async Task<HistorianHysteria> CreateChallenge()
        {
            HistorianHysteria task = new HistorianHysteria();
            string taskData = await task.GetInputStringFromUrl(Url);
            task.ExtractInput(taskData);
            return task;
        }

        public override int ProcessPart1()
        {
            int runningDistanceTotal = 0;
            int[] column1 = this.Data.Select(i => i.Item1).Order().ToArray(),
                  column2 = this.Data.Select(i => i.Item2).Order().ToArray();

            for (int i = 0; i < this.Data.Count(); i++)
            {
                runningDistanceTotal += Math.Abs(column2[i] - column1[i]);
            }
            return runningDistanceTotal;
        }

        public override int ProcessPart2()
        {
            int runningSimilarityScore = 0;
            for (int i = 0; i < this.Data.Count(); i++)
            {
                int currInt = this.Data.ElementAt(i).Item1;
                int matches = this.Data.Where(d => d.Item2 == currInt).Count();
                runningSimilarityScore += matches * currInt;
            }
            return runningSimilarityScore;
        }

        public override void ExtractInput(string input)
        {
            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

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
