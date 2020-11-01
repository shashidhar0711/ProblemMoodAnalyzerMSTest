using System;

namespace ProblemMoodAnalyzerMSTest
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            MoodAnalyzeFactory.CreateMoodAnalyzerObject("ProblemMoodAnalyzerMSTest.MoodAnalyzer", "MoodAnalyzer");
        }
    }
}
