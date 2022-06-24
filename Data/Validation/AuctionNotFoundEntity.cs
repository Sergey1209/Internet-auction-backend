using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Validation
{
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
