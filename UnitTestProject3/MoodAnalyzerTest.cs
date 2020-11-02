using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemMoodAnalyzerMS;

namespace UnitTestProject3
{
    [TestClass]
    public class MoodAnalyzerTest
    {
        private readonly MoodAnalyzer moodAnalyzer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyzerTest"/> class.
        /// </summary>
        public MoodAnalyzerTest()
        {
            moodAnalyzer = new MoodAnalyzer();
        }

        /// <summary>
        /// 1.1 Analyzes the mood return sad.
        /// </summary>
        [TestMethod]
        public void GivenSadMood_ShouldReturnSad()
        {
            /// Arrange
            string message = "I am in sad Mood";

            /// Act    
            string result = moodAnalyzer.AnalyzeMood(message);

            /// Assert
            Assert.AreEqual("sad", result);
        }

        /// <summary>
        /// 1.2 Given any mood it should return happy.
        /// </summary>
        [TestMethod]

        public void GivenAnyMood_ShouldReturnHappy()
        {
            /// Arrange
            string message = "I am in happy Mood";

            /// Act    
            string result = moodAnalyzer.AnalyzeMood(message);

            /// Assert
            Assert.AreEqual("happy", result);
        }

        /// <summary>
        /// 2.1 Givens the null mood should return happy.
        /// </summary>
        [TestMethod]
        public void GivenNullMood_ShouldReturnHappy()
        {
            /// Arrange
            string message = "I am not in Mood";

            /// Act    
            string result = moodAnalyzer.AnalyzeMood(message);

            /// Assert
            Assert.AreEqual("happy", result);
        }

        /// <summary>
        /// 3.1 Given the empty mood should throw mood cannot be empty.
        /// </summary>
        [TestMethod]
        public void GivenEmptyMood_ShouldThrowMoodCannotBeEmpty()
        {
            try
            {
                /// Arrange
                string message = "";

                /// Act
                string mood = moodAnalyzer.AnalyzeMood(message);
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                /// Assert
                Assert.AreEqual("Mood should not be empty", Exception.Message);
            }
        }

        /// <summary>
        /// 3.2 Given the invalid mood should throw mood cannot be invalid.
        /// </summary>
        [TestMethod]
        public void GivenInvalidMood_ShouldThrowMoodCannotBeInvalid()
        {
            /// Arrange
            string message = "I am not in mood";

            /// Act
            string mood = moodAnalyzer.AnalyzeMood(message);

            /// Assert
            Assert.AreEqual("happy", mood);
        }

        /// <summary>
        /// 3.3 Given the null mood should throw mood cannot be null.
        /// </summary>
        [TestMethod]
        public void GivenNullMood_ShouldThrowMoodCannotBeNull()
        {
            /// Arrange
            string message = "NULL";

            /// Act
            string mood = moodAnalyzer.AnalyzeMood(message);

            /// Assert
            Assert.AreEqual("happy", mood);
        }

        /// <summary>
        /// 4.1 Givens the mood analyzer class name should return mood analyzer object.
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyzerClassName_ShouldReturnMoodAnalyzerObject()
        {
            /// Arrange
            string className = "ProblemMoodAnalyzerMSTest.MoodAnalyzer";
            string constructorName = "MoodAnalyzer";
            object expectedObj = new MoodAnalyzer();

            /// Act
            object resultObj = MoodAnalyzeReflector.CreateMoodAnalyzerObject(className, constructorName);

            /// Assert
            Assert.AreEqual(expectedObj, resultObj);
            //expected.Equals(obj);
        }

        /// <summary>
        /// 4.2 Giving the improper class name should throw mood analyzer exception ie gives no such class.
        /// </summary>
        [TestMethod]
        public void GivenImproperClassName_ShouldThrowMoodAnalyzerException_ItShouldGiveNoSuchClass()
        {
            try
            {
                /// Act
                object resultObj = MoodAnalyzeReflector.CreateMoodAnalyzerObject("ProblemMoodAnalyzerMSTestClass.MoodAnalyzer", "MoodAnalyzer");
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                /// Assert
                Assert.AreEqual("Class Not Found", Exception.Message);
            }
        }
        /// <summary>
        /// 4.3 Giving improper constructor name should throw mood analyzer exception ie gives no such method
        /// </summary>
        [TestMethod]
        public void GivenImproperConstructorName_ShouldThrowMoodAnalyzerException_ItShouldGiveNoSuchConstructor()
        {
            try
            {
                //Act
                object obresultObjj = MoodAnalyzeReflector.CreateMoodAnalyzerObject("ProblemMoodAnalyzerMSTest.MoodAnalyzer", "NullMoodAnalyzer");
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                //Assert
                Assert.AreEqual("Constructor Not Found", Exception.Message);
            }
        }

        /// <summary>
        /// 5.1 Giving the mood analyzer class name should return mood analyzer object using parametrized constructor.
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
            object resultObj = MoodAnalyzeReflector.CreateMoodAnalyzerUsingParameterizedConstructor(className, constructorName, "happy");

            /// Assert
            expectedObj.Equals(resultObj);
        }

        /// <summary>
        /// 5.2 Giving the improper class name should throw mood analyzer exception using parameterized constructor it should give no such class.
        /// </summary>
        [TestMethod]
        public void GivenImproperClassName_ShouldThrowMoodAnalyzerExceptionUsingParameterizedConstructor_ItShouldGiveNoSuchClass()
        {
            try
            {
                /// Act
                object resultObj = MoodAnalyzeReflector.CreateMoodAnalyzerUsingParameterizedConstructor("ProblemMoodAnalyzer.MoodAnalyzer", "MoodAnalyzer", "sad");
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                /// Assert
                Assert.AreEqual("Class Not Found", Exception.Message);
            }
        }

        /// <summary>
        /// 5.3 Giving the improper constructor should throw mood analyzer exception using parameteried constructor it should give no such method.
        /// </summary>
        [TestMethod]
        public void GivenImproperConstructor_ShouldThrowMoodAnalyzerExceptionUsingParameteriedConstructor_ItShouldGiveNoSuchMethod()
        {
            try
            {
                /// Act
                object resultObj = MoodAnalyzeReflector.CreateMoodAnalyzerUsingParameterizedConstructor("ProblemMoodAnalyzerMSTest.MoodAnalyzer", "ConstructorMoodAnalyzer", "sad");
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                /// Assert
                Assert.AreEqual("Constructor Not Found", Exception.Message);
            }
        }

        /// <summary>
        /// 6.1 Giving the happy mood should return happy.
        /// </summary>
        [TestMethod]
        public void GivenHappyMood_ShouldReturnHappy()
        {
            /// Arrange
            string expected = "happy";

            /// Act
            string result = MoodAnalyzeReflector.InvokeAnalyzeMood(expected, "AnalyzeMood");

            /// Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// 6.2 Giving the improper method name should throw mood analysis exception ie Method Not Found
        /// </summary>
        [TestMethod]
        public void GivenImproperMethodName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                /// Arrange
                string message = "happy";
                string methodName = "AnalyseMood";

                /// Act
                string result = MoodAnalyzeReflector.InvokeAnalyzeMood(message, methodName);
            }
            catch (AnalyzeMoodCustomizedException exception)
            {
                /// Assert
                Assert.AreEqual("Method Not Found", exception.Message);
            }
        }

        /// <summary>
        /// 7.1 Giving the proper field name happy mood message it should return happy.
        /// </summary>
        [TestMethod]
        public void GivenProperFieldName_HappyMoodMessage_ItShouldReturnHAPPY()
        {
            ///Arrange
            //string mood = "I am happy in today";
            //string fieldName = "message";
            /// Act
            object resultObj = MoodAnalyzeReflector.SetFieldValue("happy", "message");

            /// Assert
            Assert.AreEqual("happy", resultObj);
        }
        /// <summary>
        /// 7.2 Giving the improper field name happy mood message it should return no such field found.
        /// </summary>
        [TestMethod]
        public void GivenImproperFieldName_HappyMoodMessage_ItShouldReturnNoSuchFieldFound()
        {
            try
            {
                /// Arrange
                string mood = "I am in happy mood";
                string fieldName = "ImproperField";

                /// Act
                object actual = MoodAnalyzeReflector.SetFieldValue(mood, fieldName);
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                /// Assert
                Assert.AreEqual("No Such Field Found", Exception.Message);
            }
        }

        /// <summary>
        /// 7.3 Giving the proper field name and mood is null it should return mood should not be null.
        /// </summary>
        [TestMethod]
        public void GivenProperFieldNameAndMoodIsNULL_ItShouldReturnMoodShouldNotBeNULL()
        {
            try
            {
                /// Arrange
                string mood = null;
                string fieldName = "message";

                /// Act
                object actual = MoodAnalyzeReflector.SetFieldValue(mood, fieldName);
            }
            catch (AnalyzeMoodCustomizedException Exception)
            {
                /// Assert
                Assert.AreEqual("Mood Should Not Be Null", Exception.Message);
            }
        }
    }
}
