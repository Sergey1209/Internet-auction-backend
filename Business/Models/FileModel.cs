using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class FileModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] ContentData { get; set; }
        [Required]
        public string ContentType { get; set; }
    }
}
