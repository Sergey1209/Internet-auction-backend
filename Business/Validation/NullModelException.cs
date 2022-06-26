using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation
{
    public class NullModelException : AuctionBusinessException
    {
        public NullModelException(string message) : base(message)
        {
        }
    }
}
