using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemMoodAnalyzerMSTest;
using MoodAnalyzerTest;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class MoodAnalyzerTest
    {
        /// <summary>
        /// Given the empty mood should throw mood cannot be empty.
        /// </summary>
        [TestMethod]
        public void GivenEmptyMood_ShouldThrowMoodCannotBeEmpty()
        {
            try
            {
                /// Arrange
                string message = "";
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

                /// Act
                string mood = moodAnalyzer.AnalyzeMood();
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                /// Assert
                Assert.AreEqual("Mood should not be empty", Exception.Message);
            }
        }

        [TestMethod]
        public void GivenInvalidMood_ShouldThrowMoodCannotBeInvalid()
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
        public void GivenNullMood_ShouldThrowMoodCannotBeNull()
        {
            /// Arrange
            string message = "NULL";
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

            /// Act
            string mood = moodAnalyzer.AnalyzeMood();

            /// Assert
            Assert.AreEqual("happy", mood);
        }

        /// <summary>
        /// Givens the mood analyzer class name should return mood analyzer object.
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyzerClassName_ShouldReturnMoodAnalyzerObject()
        {
            /// Arrange
            string className = "ProblemMoodAnalyzerMSTest.MoodAnalyzer";
            string constructorName = "MoodAnalyzer";
            object expected = new MoodAnalyzer();

            /// Act
            object obj = MoodAnalyzeFactory.CreateMoodAnalyzerObject(className, constructorName);

            /// Assert
            Assert.AreEqual(expected, obj);
            //expected.Equals(obj);
        }

        /// <summary>
        /// Giving the improper class name should throw mood analyzer exception ie gives no such class.
        /// </summary>
        [TestMethod]
        public void GivenImproperClassName_ShouldThrowMoodAnalyzerException_GivesNoSuchClass()
        {
            try
            {
                /// Act
                object obj = MoodAnalyzeFactory.CreateMoodAnalyzerObject("ProblemMoodAnalyzerMSTestClass.MoodAnalyzer", "MoodAnalyzer");
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                /// Assert
                Assert.AreEqual("Class Not Found", Exception.Message);
            }
        }
        /// <summary>
        /// Giving improper constructor name should throw mood analyzer exception ie gives no such method
        /// </summary>
        [TestMethod]
        public void GivenImproperConstructorName_ShouldThrowMoodAnalyzerException_GivesNoSuchConstructor()
        {
            try
            {
                //Act
                object obj = MoodAnalyzeFactory.CreateMoodAnalyzerObject("ProblemMoodAnalyzerMSTest.MoodAnalyzer", "NullMoodAnalyzer");
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                //Assert
                Assert.AreEqual("Constructor Not Found", Exception.Message);
            }
        }
    }
}