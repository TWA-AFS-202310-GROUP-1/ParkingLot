using System;
using System.Runtime.Serialization;

namespace ParkingLot
{
    [Serializable]
    public class UnvalidTicketException : Exception
    {
        public UnvalidTicketException()
        {
        }

        public UnvalidTicketException(string message) : base(message)
        {
        }

        public UnvalidTicketException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnvalidTicketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}