using System;
using System.Runtime.Serialization;

namespace Day5
{
    [Serializable]
    public class NoParkingException : Exception
    {
        public NoParkingException()
        {
        }

        public NoParkingException(string message) : base(message)
        {
        }

        public NoParkingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoParkingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}