using System;

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
