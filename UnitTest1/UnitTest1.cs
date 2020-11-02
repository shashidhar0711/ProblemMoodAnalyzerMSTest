using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemMoodAnalyzerMSTest;

namespace MoodAnalyzeProblemTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly MoodAnalyzer moodAnalyzer;

        public UnitTest1()
        {
            moodAnalyzer = new MoodAnalyzer();
        }
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
            string result = moodAnalyzer.AnalyzeMood(message);

            /// Assert
            Assert.AreEqual("sad", result);
        }

        [TestMethod]

        public void AnalyzeMood_ReturnHappy()
        {
            /// Arrange
            string message = "I am in sad Mood";

            /// Act    
            string result = moodAnalyzer.AnalyzeMood(message);

            /// Assert
            Assert.AreEqual("happy", result);
        }
    }
}