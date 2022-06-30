namespace Data.Validation
{
    /// <summary>
    /// Represents errors that occur when an attempt to update an entity in a data source fails.
    /// </summary>
    public class AuctionUpdateException : AuctionDataException
    {
        public AuctionUpdateException(string message) : base(message)
        {
        }
    }
}
