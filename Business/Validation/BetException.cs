using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation
{
    internal class BetException : AuctionBusinessException
    {
        public BetException(string message) : base(message)
        {
        }
    }
}
