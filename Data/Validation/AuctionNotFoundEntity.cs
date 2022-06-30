using System;

namespace Data.Validation
{
    /// <summary>
    /// Represents errors that occur when an entity is not found in the data source.
    /// </summary>
    public class AuctionNotFoundEntityException : AuctionDataException
    {
        public AuctionNotFoundEntityException(string message) : base(message)
        {

        }

        public AuctionNotFoundEntityException(string message, Exception innerException) : base(message, innerException)
        {

        }

    }
}
