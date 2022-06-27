namespace Business.Validation
{
    public class NullModelException : AuctionBusinessException
    {
        public NullModelException(string message) : base(message)
        {
        }
    }
}
