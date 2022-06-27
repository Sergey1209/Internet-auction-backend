namespace Business.Validation
{
    public class RegistrationException : AuctionBusinessException
    {
        public RegistrationException() : base("Login is being used by another user")
        {
        }
    }
}
