using System;
using System.Runtime.Serialization;

namespace BLL.Exceptions
{
    [Serializable]
    public class ServicesException : Exception
    {
        public ServicesException()
        {

        }

        public ServicesException(string message)
            : base(message)
        {

        }

        public ServicesException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public ServicesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
