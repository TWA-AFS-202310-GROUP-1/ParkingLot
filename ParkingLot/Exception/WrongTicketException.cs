using System;
using System.Runtime.Serialization;

namespace ParkingLotManagement.Exception
{
    [Serializable]
    public class WrongTicketException : SystemException
    {
        public WrongTicketException()
        {
        }

        public WrongTicketException(string message) : base(message)
        {
        }

        public WrongTicketException(string message, SystemException innerException) : base(message, innerException)
        {
        }

        protected WrongTicketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}