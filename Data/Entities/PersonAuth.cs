using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class PersonAuth : BaseEntity
    {
        public int PersonId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public Person Person { get; set; }
    }
}
