using System;

namespace Data.Validation
{
    public class AuctionUpdateException : AuctionDataException
    {
        public AuctionUpdateException(string message) : base(message)
        {
        }
    }
}
