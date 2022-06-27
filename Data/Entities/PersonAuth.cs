namespace Data.Entities
{
    public class PersonAuth
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
