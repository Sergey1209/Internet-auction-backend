using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class BaseEntity : ICloneable
    {
        public int Id { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
