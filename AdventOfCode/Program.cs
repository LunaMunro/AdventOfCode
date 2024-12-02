using AdventOfCode;
using AdventOfCode.Challenges.HistorianHysteria;
using AdventOfCode.Challenges.RedNosedReports;

ChallengeBase task = await RedNosedReports.CreateChallenge("https://adventofcode.com/2024/day/2/input");
var answer = task.ProcessPart1();
Console.WriteLine(answer);

answer = task.ProcessPart2();
Console.WriteLine(answer);