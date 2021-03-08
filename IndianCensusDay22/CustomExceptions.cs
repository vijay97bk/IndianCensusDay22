using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusDay22
{
   public class CustomExceptions : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            FILE_NOT_EXISTS, WRONG_EXTENSION, DELIMITER_NOT_FOUND,
            INCORRECT_HEADER
        }
        public CustomExceptions()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyserException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        public CustomExceptions(ExceptionType type, string name) : base(name)
        {
            this.type = type;
        }
    }
}
