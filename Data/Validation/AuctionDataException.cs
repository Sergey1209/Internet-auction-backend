using System;
using System.Collections.Generic;
using System.Text;

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
