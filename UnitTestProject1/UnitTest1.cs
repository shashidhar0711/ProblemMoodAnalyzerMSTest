using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            string message = "I am not in Mood";

            /// Act    
            string result = moodAnalyzer.AnalyzeMood(message);

            /// Assert
            Assert.AreEqual("happy", result);
        }

        [TestMethod]
     
        public void AnalyzeMood_ReturnHappy()
        {
            /// Arrange
            string message = "NULL";

            /// Act    
            string result = moodAnalyzer.AnalyzeMood(message);

            /// Assert
            Assert.AreEqual("happy", result);
        }
    }
}