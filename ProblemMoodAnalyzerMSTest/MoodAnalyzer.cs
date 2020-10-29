using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemMoodAnalyzerMSTest
{
    public class MoodAnalyzer
    {
        private string message;

        public MoodAnalyzer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyzer"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// Analyzes the mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public string AnalyzeMood()
        {
            if (message.Contains("sad"))
            {
                return "sad";
            }
            else
            {
                return "happy";
            }
        }
    }
}