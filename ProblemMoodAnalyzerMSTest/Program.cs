﻿using ProblemMoodAnalyzerMS;
using System;

namespace ProblemMoodAnalyzerMSTest
{
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            //MoodAnalyzer moodAnalyzer = new MoodAnalyzer("happy".ToUpper());
            //Console.WriteLine("The person is in " + moodAnalyzer.AnalyzeMood() + " Mood");
            MoodAnalyzeReflector.CreateMoodAnalyzerObject("ProblemMoodAnalyzerMSTest.MoodAnalyzer", "MoodAnalyzer");
        }
    }
}
