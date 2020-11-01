using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using ProblemMoodAnalyzerMSTest;

namespace ProblemMoodAnalyzerMSTest
{
    public class MoodAnalyzeFactory
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
                    throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExceptionType.NO_SUCH_METHOD, "Constructor Not Found");
                }
            }
            else
            {
                throw new AnalyzeMoodCustomizedException(AnalyzeMoodCustomizedException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
            }
        }
    }
}
