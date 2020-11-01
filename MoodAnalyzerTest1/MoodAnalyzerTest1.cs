using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemMoodAnalyzerMSTest;
using MoodAnalyzerTest1;

namespace MoodAnalyzerTest1
{
    [TestClass]
    public class MoodAnalyzerTest1
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
            object expectedObj = new MoodAnalyzer();

            /// Act
            object resultObj = MoodAnalyzeFactory.CreateMoodAnalyzerObject(className, constructorName);

            /// Assert
            Assert.AreEqual(expectedObj, resultObj);
            //expected.Equals(obj);
        }

        /// <summary>
        /// Giving the improper class name should throw mood analyzer exception ie gives no such class.
        /// </summary>
        [TestMethod]
        public void GivenImproperClassName_ShouldThrowMoodAnalyzerException_ItShouldGiveNoSuchClass()
        {
            try
            {
                /// Act
                object resultObj = MoodAnalyzeFactory.CreateMoodAnalyzerObject("ProblemMoodAnalyzerMSTestClass.MoodAnalyzer", "MoodAnalyzer");
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
        public void GivenImproperConstructorName_ShouldThrowMoodAnalyzerException_ItShouldGiveNoSuchConstructor()
        {
            try
            {
                //Act
                object obresultObjj = MoodAnalyzeFactory.CreateMoodAnalyzerObject("ProblemMoodAnalyzerMSTest.MoodAnalyzer", "NullMoodAnalyzer");
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                //Assert
                Assert.AreEqual("Constructor Not Found", Exception.Message);
            }
        }

        /// <summary>
        /// Giving the mood analyzer class name should return mood analyzer object using parametrized constructor.
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyzerClassName_ShouldReturnMoodAnalyzerObjectUsingParametrizedConstructor()
        {

            /// Arrange
            string className = "ProblemMoodAnalyzerMSTest.MoodAnalyzer";
            string constructorName = "MoodAnalyzer";
           // string message = "happy";
            MoodAnalyzer expectedObj = new MoodAnalyzer("happy");

            /// Act
            object resultObj = MoodAnalyzeFactory.CreateMoodAnalyzerUsingParameterizedConstructor(className, constructorName, "happy");

            /// Assert
            expectedObj.Equals(resultObj);
        }

        /// <summary>
        /// Giving the improper class name should throw mood analyzer exception using parameterized constructor it should give no such class.
        /// </summary>
        [TestMethod]
        public void GivenImproperClassName_ShouldThrowMoodAnalyzerExceptionUsingParameterizedConstructor_ItShouldGiveNoSuchClass()
        {
            try
            {
                /// Act
                object resultObj = MoodAnalyzeFactory.CreateMoodAnalyzerUsingParameterizedConstructor("ProblemMoodAnalyzer.MoodAnalyzer", "MoodAnalyzer", "sad");
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                /// Assert
                Assert.AreEqual("Class Not Found", Exception.Message);
            }
        }

        /// <summary>
        /// Giving the improper constructor should throw mood analyzer exception using parameteried constructor it should give no such method.
        /// </summary>
        [TestMethod]
        public void GivenImproperConstructor_ShouldThrowMoodAnalyzerExceptionUsingParameteriedConstructor_ItShouldGiveNoSuchMethod()
        {
            try
            {
                /// Act
                object resultObj = MoodAnalyzeFactory.CreateMoodAnalyzerUsingParameterizedConstructor("ProblemMoodAnalyzerMSTest.MoodAnalyzer","ConstructorMoodAnalyzer", "sad");
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                /// Assert
                Assert.AreEqual("Constructor Not Found", Exception.Message);
            }
        }
    }
}
