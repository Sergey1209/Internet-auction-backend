using System;

namespace Business.Validation
{
    public class AuctionBusinessException : Exception
    {
        public AuctionBusinessException(string message) : base(message)
        {
        }
    }
}
