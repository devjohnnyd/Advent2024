using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2024.Days
{
    public class Day1 : IAdventDay
    {
        public string SolvePart1(string input)
        {
            // Use the input parameter as the file path
            string filePath = input;

            if (!File.Exists(filePath))
            {
                return "The specified file does not exist.";
            }

            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Parse the numbers into two separate lists
                List<int> column1 = new List<int>();
                List<int> column2 = new List<int>();

                foreach (string line in lines)
                {
                    var numbers = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

                    if (numbers.Length != 2)
                    {
                        return $"Invalid line: '{line}'. Each line must contain exactly two numbers.";
                    }

                    column1.Add(numbers[0]);
                    column2.Add(numbers[1]);
                }

                // Ensure both columns have the same number of elements
                if (column1.Count != column2.Count)
                {
                    return "The file does not contain equal numbers of entries in both columns.";
                }

                // Sort both columns
                column1.Sort();
                column2.Sort();

                // Calculate the total sum of differences
                int totalDifference = 0;
                for (int i = 0; i < column1.Count; i++)
                {
                    totalDifference += Math.Abs(column1[i] - column2[i]);
                }

                // Return the result
                return "The total sum of differences is: " + totalDifference;
            }
            catch (Exception ex)
            {
                return "An error occurred while processing the file: " + ex.Message;
            }
        }

        public string SolvePart2(string input)
        {
            // Use the input parameter as the file path
            string filePath = input;

            if (!File.Exists(filePath))
            {
                return "The specified file does not exist.";
            }

            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Parse the numbers into two separate lists
                List<int> column1 = new List<int>();
                List<int> column2 = new List<int>();

                foreach (string line in lines)
                {
                    var numbers = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

                    if (numbers.Length != 2)
                    {
                        return $"Invalid line: '{line}'. Each line must contain exactly two numbers.";
                    }

                    column1.Add(numbers[0]);
                    column2.Add(numbers[1]);
                }

                // Ensure both columns have the same number of elements
                if (column1.Count != column2.Count)
                {
                    return "The file does not contain equal numbers of entries in both columns.";
                }

                // Calculate the similarity score
                var column2Frequency = column2.GroupBy(n => n)
                                              .ToDictionary(g => g.Key, g => g.Count());

                int similarityScore = 0;
                foreach (int number in column1)
                {
                    if (column2Frequency.TryGetValue(number, out int frequency))
                    {
                        similarityScore += number * frequency;
                    }
                }

                // Return the similarity score
                return "The total similarity score is: " + similarityScore;
            }
            catch (Exception ex)
            {
                return "An error occurred while processing the file: " + ex.Message;
            }
        }

    }
}
