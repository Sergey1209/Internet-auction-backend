namespace Business.Validation
{
    internal class RequaredFildOfModelException : AuctionBusinessException
    {
        public RequaredFildOfModelException(string message) : base($"Required field not filled: {message}")
        {
        }
    }
}
