using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace League.validator
{
    class ValidationException : ApplicationException
    {
        public ValidationException() { }

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, Exception innerException) : base(message, innerException) { }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

