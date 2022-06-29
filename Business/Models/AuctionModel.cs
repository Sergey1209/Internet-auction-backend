using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class AuctionModel
    {   
        public int LotId { get; set; }
        public int OwnerId { get; set; }
        public string CustomerNickname { get; set; }
        public DateTime Deadline { get; set; }
        public decimal BetValue { get; set; }
        public string LotName { get; set; }
        public string LotDescription { get; set; }
        public IEnumerable<string> LotImages { get; set; }
    }
}
