using Business.Interfaces;
using Business.Validation;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    /// <summary>
    /// The model accepting data from the request in the LotCategoryСontroller. 
    /// </summary>
    public class InputLotCategoryModel : IValidatelyModel
    {
        /// <summary>
        /// Category ID
        /// </summary>
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Images associated with this category.
        /// </summary>
        public IFormFile File { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new RequaredFildOfModelException("Name");
        }
    }
}
