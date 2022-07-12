namespace Business.Validation
{
    public class AuthorizationExeption : AuctionBusinessException
    {
        public AuthorizationExeption() : base("Not authorized user")
        {
        }
    }
}
