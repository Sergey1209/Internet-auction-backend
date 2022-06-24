using Business.Interfaces;
using Business.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class InputLotCategoryModel : IValidatelyModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<IFormFile> Files { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new RequaredFildOfModelException("Name");
        }
    }
}
