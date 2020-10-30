using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemMoodAnalyzerMSTest
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
        public string AnalyzeMood()
        {
            try
            {
                if(this.message.Equals(string.Empty))
                {
                    throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExcetionType.EMPTY_MESSAGE, "Mood should not be empty");
                }
                if (this.message.Contains("sad"))
                {
                    return "";
                }
                else
                {
                    return "happy";
                }
            }
            catch(NullReferenceException)
            {
                throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExcetionType.EMPTY_NULL, "Mood should not be Null");
            }

        }
    }
}