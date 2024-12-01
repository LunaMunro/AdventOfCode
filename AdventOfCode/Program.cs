using AdventOfCode;
using AdventOfCode.HystorianHysteria;

TaskBase task = new HystorianHysteria("https://adventofcode.com/2024/day/1/input");
var answer = await task.ProcessPart1();
Console.WriteLine(answer);

answer = await task.ProcessPart2();
Console.WriteLine(answer);