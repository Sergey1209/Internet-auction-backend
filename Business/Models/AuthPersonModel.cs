using Business.Interfaces;
using Business.Validation;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class PersonAuthModel : IValidatelyModel
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Nickname { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Email))
                throw new RequaredFildOfModelException("Login");

            if (string.IsNullOrEmpty(Password))
                throw new RequaredFildOfModelException("Password");

            if (string.IsNullOrEmpty(Nickname))
                throw new RequaredFildOfModelException("Nickname");

            if (PersonId <= 0)
                throw new RequaredFildOfModelException("OwnerId");
        }
    }
}
