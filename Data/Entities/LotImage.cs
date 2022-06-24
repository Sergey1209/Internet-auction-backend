namespace Data.Entities
{
    public class LotImage : BaseEntity
    {
        public int LotId { get; set; }
        public int FileId { get; set; }

        public virtual Lot Lot { get; set; }
        public virtual File File { get;set; }

    }
}
