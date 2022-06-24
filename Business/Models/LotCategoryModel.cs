using Business.Interfaces;
using Business.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class LotCategoryModel : IValidatelyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlIcon { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new RequaredFildOfModelException("Name");
        }
    }
}
