using System;
using System.Collections.Generic;

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
        public DateTime InitialDate { get; set; }

        public IEnumerable<string> LotImages { get; set; }
    }
}
