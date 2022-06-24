using Business.Interfaces;
using Business.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class LotModel : IValidatelyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? InitialPrice { get; set; }
        public int CategoryId { get; set; }
        public DateTime? Deadline { get; set; }
        public int OwnerId { get; set; }
        
        public string OwnerName { get; set; }
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
