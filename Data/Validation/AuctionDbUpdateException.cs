using System;

namespace Data.Validation
{
    public class AuctionDbUpdateException : AuctionDataException
    {
        public AuctionDbUpdateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
