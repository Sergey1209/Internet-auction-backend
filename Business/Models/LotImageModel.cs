using Business.Interfaces;

namespace Business.Models
{
    public class LotImageModel
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public int FileId { get; set; }

    }
}