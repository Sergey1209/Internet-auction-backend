using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    /// <summary>
    /// The model accepting data from the request in the LotСontroller. 
    /// </summary>
    public class InputLotModel
    {
        /// <summary>
        /// Lot ID
        /// </summary>
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Initial Price set by the owner
        /// </summary>
        public decimal? InitialPrice { get; set; }
        public int CategoryId { get; set; }

        /// <summary>
        /// Deadline auction for this lot
        /// </summary>
        public DateTime? Deadline { get; set; }

        /// <summary>
        /// PersonId who owns the lot
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Images associated with this lot.
        /// </summary>
        public IEnumerable<IFormFile> Files { get; set; }

    }
}
