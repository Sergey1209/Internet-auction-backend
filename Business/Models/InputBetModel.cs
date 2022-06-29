using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class InputBetModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int BetValue { get; set; }
    }
}
