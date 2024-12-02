using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Days
{
    public class Day2 : IAdventDay
    {
        public string SolvePart1(string input)
        {
            string x = File.ReadAllText(input);
            var reports = x.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int safeReportCount = 0;

            foreach (var report in reports)
            {
                var levels = report.Split(' ').Select(int.Parse).ToList();

                if (levels.Count < 2)
                {
                    continue; // Skip invalid reports.
                }

                bool isIncreasing = true;
                bool isDecreasing = true;

                for (int i = 1; i < levels.Count; i++)
                {
                    int diff = Math.Abs(levels[i] - levels[i - 1]); // Use absolute value

                    if (diff < 1 || diff > 3) // Check if difference is within valid range
                    {
                        isIncreasing = false;
                        isDecreasing = false;
                        break; // No need to check further if the report is invalid.
                    }

                    if (levels[i] < levels[i - 1]) isIncreasing = false; // Not increasing if current level is less than the previous
                    if (levels[i] > levels[i - 1]) isDecreasing = false; // Not decreasing if current level is greater than the previous
                }

                if (isIncreasing || isDecreasing)
                {
                    safeReportCount++;
                }
            }

            return safeReportCount.ToString(); // Convert the count to a string and return it.
        }


        public string SolvePart2(string input)
        {
            // Implement Part 2 logic here
            return string.Empty;
        }
    }
}
