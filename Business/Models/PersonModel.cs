using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class PersonModel : RegistrationModel
    {
        [Required]
        public int PersonId { get; set; }
    }
}
