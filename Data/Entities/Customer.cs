﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Customer : BaseEntity
    {
        public int PersonId { get; set; }

        public Person Person { get; set; }
        public IEnumerable<Receipt> Receipts { get; set; }
    }
}
