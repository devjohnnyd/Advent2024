using Advent2024;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Program.cs
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter day number:");
        int dayNumber = int.Parse(Console.ReadLine());


        var day = DayFactory.GetDay(dayNumber);

        Console.WriteLine("Part 1:");
        Console.WriteLine(day.SolvePart1("C:\\Projects\\Advent2024\\puzzle-input\\Day 1\\part1\\input.txt"));

        Console.WriteLine("Part 2:");
        Console.WriteLine(day.SolvePart2("C:\\Projects\\Advent2024\\puzzle-input\\Day 1\\part1\\input.txt"));
    }
}

