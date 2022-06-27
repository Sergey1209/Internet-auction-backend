using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class RegistrationModel : LoginModel
    {
        [Required]
        public string Nickname { get; set; }
    }
}
