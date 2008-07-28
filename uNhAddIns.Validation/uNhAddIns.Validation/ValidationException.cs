using System;

namespace uNhAddIns.Validation {
    using System.Runtime.Serialization;

    public class ValidationException : Exception 
    {
        public ValidationException(SerializationInfo info, StreamingContext context) 
            : base(info, context) {

        }

        public ValidationException(string message, Exception innerException) 
            : base(message, innerException) {

        }

        public ValidationException(string message) 
            : base(message) {

        }

        public ValidationException() {

        }
    }
}
