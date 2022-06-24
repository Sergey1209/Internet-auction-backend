namespace Business.Validation
{
    public class LoginException : AuctionBusinessException
    {
        public LoginException() : base("Invalid username or password.")
        {
        }
    }
}
