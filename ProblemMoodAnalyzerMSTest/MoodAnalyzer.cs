using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemMoodAnalyzerMS
{
    public class MoodAnalyzer
    {
        /// <summary>
        /// Instance Variable
        /// </summary>
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
        /// Analyzes the mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public string AnalyzeMood(string message)
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    /// Throws Mood should not be empty
                    throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                }
                if (this.message.Contains("sad"))
                {
                    return "sad";
                }
                else
                {
                    return "happy";
                }
            }
            catch (NullReferenceException)
            {
                /// Throws Mood should not be null
                throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExceptionType.EMPTY_NULL, "Mood should not be null");
            }

        }
    }
}