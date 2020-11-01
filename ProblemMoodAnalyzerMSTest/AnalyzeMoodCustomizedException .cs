using System;
using System.Collections.Generic;
using System.Text;
using ProblemMoodAnalyzerMSTest;

namespace ProblemMoodAnalyzerMSTest
{
    public class AnalyzeMoodCustomizedException : Exception
    {
        /// <summary>
        /// Enum For Exception Type
        /// </summary>
        public enum ExceptionType
        {
            ENTERED_NULL, ENTERED_EMPTY, NO_SUCH_FIELD, NO_SUCH_METHOD, NO_SUCH_CLASS,
            OBJECT_CREATION_ISSUE, EMPTY_MESSAGE, EMPTY_NULL
        }

        /// Creating type Variable of type ExceptionType
        ExceptionType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeMoodCustomizedException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="message">The message.</param>
        public AnalyzeMoodCustomizedException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
