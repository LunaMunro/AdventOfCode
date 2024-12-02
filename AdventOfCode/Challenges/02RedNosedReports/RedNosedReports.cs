using System;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace AdventOfCode.Challenges.RedNosedReports
{
    internal class RedNosedReports : ChallengeBase
    {
        private static readonly string Url = "https://adventofcode.com/2024/day/2/input";

        private IEnumerable<IEnumerable<int>> Data;

        private RedNosedReports() { } // Private constructor to enforce factory method usage

        public static async Task<RedNosedReports> CreateChallenge()
        {
            RedNosedReports task = new RedNosedReports();
            string taskData = await task.GetInputStringFromUrl(Url);
            task.ExtractInput(taskData);
            return task;
        }

        public override int ProcessPart1()
        {
            return this.Data.Where(r => this.IsSafe(r.ToList())).Count();
        }

        public override int ProcessPart2()
        {
            return this.Data.Where(r => this.IsSafeWithDampener(r.ToList())).Count();
        }

        private bool IsSafe(IEnumerable<int> report)
        {
            var differences = report.Zip(report.Skip(1), (a, b) => a - b);
            return differences.All(d => d >= 1 && d <= 3) || differences.All(d => d <= -1 && d >= -3);
        }

        private bool IsSafeWithDampener(List<int> report)
        {
            return Enumerable.Range(0, report.Count()).
                Any(i => this.IsSafe(report.Where((num, index) => index != i)));
        }

        public override void ExtractInput(string input)
        {
            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var data = new List<IEnumerable<int>>();

            foreach (var line in lines)
            {
                var numbers = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse);

                data.Add(numbers);
            }
            this.Data = data;
        }
    }
}
