using Business.Interfaces;
using Business.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class InputLotModel : IValidatelyModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? InitialPrice { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public DateTime? Deadline { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public IEnumerable<IFormFile> Files { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new RequaredFildOfModelException("Name");

            if (OwnerId <= 0)
                throw new RequaredFildOfModelException("OwnerId");

            if (CategoryId <= 0)
                throw new RequaredFildOfModelException("CategoryId");

        }
    }
}
