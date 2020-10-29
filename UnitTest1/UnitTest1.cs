using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemMoodAnalyzerMSTest;

namespace MoodAnalyzeProblemTest
{
    [TestClass]
    public class UnitTest1
    {
        private static string message;

        /// Creating Reference of Object Class
        /// It is invoking during Object Creation.
        MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

        /// <summary>
        /// Analyzes the Mood and, It returns Sad
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void AnalyzeMood_ReturnSad()
        {
            /// Arrange
            string message = "I am in sad Mood";

            /// Act
            string result = moodAnalyzer.AnalyzeMood();

            /// Assert
            Assert.AreEqual("sad", result);
        }

        [TestMethod]

        /// <summary>
        /// Analyzes the Mood and, It returns Happy
        /// </summary>
        /// <returns></returns>
        public void AnalyzeMood_ReturnHappy()
        {
            /// Arrange
            string message = "I am in happy Mood";

            /// Act   
            string result = moodAnalyzer.AnalyzeMood();

            /// Assert
            Assert.AreEqual("happy", result);
        }
    }
}