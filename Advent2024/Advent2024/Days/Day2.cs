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
            string x = File.ReadAllText(input);
            var reports = x.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int safeReportCount = 0;

            foreach (var report in reports)
            {
                var levels = report.Split(' ').Select(int.Parse).ToList();

                // Check if the report is safe as is or can be made safe by removing one level
                if (IsSafe(levels) || CanBeMadeSafe(levels))
                {
                    safeReportCount++;
                }
            }

            return safeReportCount.ToString();

            // Determines if a report is safe
            bool IsSafe(List<int> levels)
            {
                if (levels.Count < 2)
                    return false;

                bool isIncreasing = true;
                bool isDecreasing = true;

                for (int i = 1; i < levels.Count; i++)
                {
                    int diff = Math.Abs(levels[i] - levels[i - 1]);

                    if (diff < 1 || diff > 3)
                        return false;

                    if (levels[i] < levels[i - 1]) isIncreasing = false;
                    if (levels[i] > levels[i - 1]) isDecreasing = false;
                }

                return isIncreasing || isDecreasing;
            }

            // Checks if a report can be made safe by removing one level
            bool CanBeMadeSafe(List<int> levels)
            {
                for (int i = 0; i < levels.Count; i++)
                {
                    var modifiedLevels = new List<int>(levels);
                    modifiedLevels.RemoveAt(i); // Remove the "bad" level

                    if (IsSafe(modifiedLevels))
                    {
                        return true; // If safe after removal, count as safe
                    }
                }

                return false;
            }
        }

    }
}
