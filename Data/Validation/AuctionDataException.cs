using System;

namespace Data.Validation
{
    public class AuctionDataException : Exception
    {
        public AuctionDataException(string message) : base(message)
        {

        }

        public AuctionDataException(string message, Exception innerException) : base(message, innerException)
        {

        }

    }
}
