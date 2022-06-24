using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation
{
    internal class RequaredFildOfModelException : AuctionBusinessException
    {
        public RequaredFildOfModelException(string message) : base($"Required field not filled: {message}")
        {
        }
    }
}
