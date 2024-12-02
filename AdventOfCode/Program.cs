using AdventOfCode;
using AdventOfCode.Challenges.HistorianHysteria;
using AdventOfCode.Challenges.RedNosedReports;

ChallengeBase task = await GetChallengeBase(2);

var answer = task.ProcessPart1();
Console.WriteLine(answer);

answer = task.ProcessPart2();
Console.WriteLine(answer);

static async Task<ChallengeBase> GetChallengeBase(int day)
{
    switch (day)
    {
        case 1:
            return await HistorianHysteria.CreateChallenge();
        case 2:
            return await RedNosedReports.CreateChallenge();
        default:
            throw new ArgumentException("Unimplemented date given!");
    }
}