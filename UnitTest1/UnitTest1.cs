using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemMoodAnalyzerMSTest;

namespace MoodAnalyzeProblemTest
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Analyzes the Mood and, It returns Sad
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void AnalyzeMood_ReturnSad()
        {
            /// Arrange
            string message = "I am in sad Mood";

            /// Act    string
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
            string result = moodAnalyzer.AnalyzeMood();

            /// Assert
            Assert.AreEqual("sad", result);
        }

        [TestMethod]

        public void AnalyzeMood_ReturnHappy()
        {
            /// Arrange
            string message = "I am in happy Mood";

            /// Act   
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
            string result = moodAnalyzer.AnalyzeMood();

            /// Assert
            Assert.AreEqual("happy", result);
        }
    }
}