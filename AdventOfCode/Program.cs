using AdventOfCode;
using AdventOfCode.Challenges.HistorianHysteria;

ChallengeBase task = await HistorianHysteria.CreateChallenge("https://adventofcode.com/2024/day/1/input");
var answer = task.ProcessPart1();
Console.WriteLine(answer);

answer = task.ProcessPart2();
Console.WriteLine(answer);