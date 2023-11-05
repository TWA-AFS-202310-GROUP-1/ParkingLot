using System;
using System.Runtime.Serialization;

namespace ParkingLotManagement.Exception
{
    [Serializable]
    public class NoPositionException : SystemException
    {
        public NoPositionException()
        {
        }

        public NoPositionException(string message) : base(message)
        {
        }

        public NoPositionException(string message, RankException innerException) : base(message, innerException)
        {
        }

        protected NoPositionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}