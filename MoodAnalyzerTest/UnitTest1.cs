using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemMoodAnalyzerMSTest;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]       
        public void GivenEmptyMoodShouldThrowMoodCannotBeEmpty()
        {
            try
            {
                string message = "";
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

                string mood = moodAnalyzer.AnalyzeMood();
            }
            catch(AnalyzeMoodCustomizedException Exception)
            {
                Assert.AreEqual("Mood should not be empty", Exception.Message);
            }
        }

        [TestMethod]
        public void GivenEmptyMoodShouldThrowMoodCannotBeNull()
        {
            string message = "I am not in mood";
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

            string mood = moodAnalyzer.AnalyzeMood();

            Assert.AreEqual("happy", mood);
        }
    }
}
