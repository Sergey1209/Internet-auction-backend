using Business.Interfaces;
using Business.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace Business.Models
{
    public class InputLotModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? InitialPrice { get; set; }
        public int CategoryId { get; set; }
        public DateTime? Deadline { get; set; }
        public int OwnerId { get; set; }
        public IEnumerable<IFormFile> Files { get; set; }

    }
}
