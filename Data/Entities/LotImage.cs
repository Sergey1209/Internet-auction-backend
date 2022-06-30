namespace Data.Entities
{
    /// <summary>
    /// Only for lots
    /// </summary>
    public class LotImage : BaseEntity
    {
        /// <summary>
        /// Lot id, only for lots.
        /// </summary>
        public int LotId { get; set; }
        /// <summary>
        /// File id, only for lots
        /// </summary>
        public int FileId { get; set; }

        public virtual Lot Lot { get; set; }
        public virtual File File { get; set; }

    }
}
