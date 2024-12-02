using Advent2024.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024
{
    // DayFactory.cs
    public static class DayFactory
    {
        public static IAdventDay GetDay(int dayNumber)
        {
            return dayNumber switch
            {
                1 => new Day1(),
                2 => new Day2(),    
                // Add more days as needed
                _ => throw new ArgumentException("Day not implemented")
            };
        }
    }

}
