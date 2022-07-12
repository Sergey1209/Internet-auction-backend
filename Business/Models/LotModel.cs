using Business.Interfaces;
using Business.Validation;
using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class LotModel : IValidatelyModel
    {
        public int Id { get; set; }
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
        public int AuctionId { get; set; }
        public decimal? BetValue { get; set; }

        public string OwnerName { get; set; }
        public DateTime InitialDate { get; set; }


        /// <summary>
        /// Images associated with this lot.
        /// </summary>
        public IEnumerable<string> Images { get; set; }

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
