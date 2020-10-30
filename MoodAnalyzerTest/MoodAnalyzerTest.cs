using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemMoodAnalyzerMSTest;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class MoodAnalyzerTest
    {
        /// <summary>
        /// Given the empty mood should throw mood cannot be empty.
        /// </summary>
        [TestMethod]       
        public void GivenEmptyMoodShouldThrowMoodCannotBeEmpty()
        {
            try
            {
                /// Arrange
                string message = "";
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

                /// Act
                string mood = moodAnalyzer.AnalyzeMood();
            }
            catch(AnalyzeMoodCustomizedException Exception)
            {
                /// Assert
                Assert.AreEqual("Mood should not be empty", Exception.Message);
            }
        }

        [TestMethod]
        public void GivenEmptyMoodShouldThrowMoodCannotBeNull()
        {
            /// Arrange
            string message = "I am not in mood";
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

            /// Act
            string mood = moodAnalyzer.AnalyzeMood();

            /// Assert
            Assert.AreEqual("happy", mood);
        }

        [TestMethod]
        public void GivenEmptyMoodShouldThrowMoodCannotBeNullAgain()
        {
            /// Arrange
            string message = "NULL";
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

            /// Act
            string mood = moodAnalyzer.AnalyzeMood();

            /// Assert
            Assert.AreEqual("happy", mood);
        }
    }
}
