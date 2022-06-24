using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation
{
    public class RegistrationException : AuctionBusinessException
    {
        public RegistrationException() : base("Login is being used by another user")
        {
        }
    }
}
