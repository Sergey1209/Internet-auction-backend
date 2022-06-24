using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class RegistrationModel : LoginModel
    {
        [Required]
        public string Nickname { get; set; }
    }
}
