using System;

namespace Data.Validation
{
    /// <summary>
    /// Represents errors that occur during application execution.
    /// </summary>
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
