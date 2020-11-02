using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ProblemMoodAnalyzerMS
{
    public class MoodAnalyzeReflector
    {
        /// <summary>
        /// Creates the mood analyzer object.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns></returns>
        /// <exception cref="AnalyzeMoodCustomizedException">
        /// Class Not Found.
        /// or
        /// Constructor Not Found.
        /// </exception>
        public static object CreateMoodAnalyzerObject(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyzeType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyzeType);
                }
                catch (ArgumentNullException)
                {
                    throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExceptionType.NO_SUCH_METHOD, "Constructor Not Found");
            }
        }

        /// <summary>
        /// Creates the mood analyser using parameterized constructor.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="AnalyzeMoodCustomizedException">
        /// constructor not found
        /// or
        /// class not found
        /// </exception>
        public static object CreateMoodAnalyzerUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyzer);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructorInfo.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExceptionType.NO_SUCH_METHOD, "Method Not Found");
            }
        }

        /// <summary>
        /// Invokes the analyse mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="AnalyzeMoodCustomizedException">No Such Method</exception>
        public static string InvokeAnalyzeMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("ProblemMoodAnalyzerMSTest.MoodAnalyzer");
                object moodAnalyzerObj = MoodAnalyzeReflector.CreateMoodAnalyzerUsingParameterizedConstructor("ProblemMoodAnalyzerMSTest.MoodAnalyzer", "MoodAnalyzer", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyzerObj, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExceptionType.NO_SUCH_METHOD, "No Such Method");
            }
        }

        public static Object SetFieldValue(string message, string fieldName)
        {
            /// Get the type of the class
            Type type = typeof(MoodAnalyzer);

            /// Create an object of class
            object mood = Activator.CreateInstance(type);

            //Get the field and If the field is not found it throws null exception and if message is empty throw exception
            // catch the exception if thrown
            try
            {
                FieldInfo fieldInfo = type.GetField(fieldName);
                fieldInfo.SetValue(mood, message);
                MethodInfo method = type.GetMethod("AnalyzeMood");
                object methodReturn = method.Invoke(mood, null);
                return methodReturn;
            }
            catch (NullReferenceException)
            {
                throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExceptionType.NO_SUCH_FIELD, "No Such Field Found");
            }
            catch
            {
                throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExceptionType.NULL_MESSAGE, "Mood Should Not Be Null");
            }
        }
    }
}
