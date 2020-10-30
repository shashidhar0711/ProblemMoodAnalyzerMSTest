using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemMoodAnalyzerMSTest
{
    public class AnalyzeMoodCustomizedException : Exception
    {
        /// <summary>
        /// Enum For Exception Type
        /// </summary>
        public enum ExcetionType
        {
            ENTERED_NULL, ENTERED_EMPTY, NO_SUCH_FIELD, NO_SUCH_METHOD, NO_SUCH_CLASS, 
            OBJECT_CREATION_ISSUE, EMPTY_MESSAGE, EMPTY_NULL
        }

        /// Creating type Variable of type ExceptionType
        ExcetionType type;

        public AnalyzeMoodCustomizedException(ExcetionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
