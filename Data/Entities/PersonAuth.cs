namespace Data.Entities
{
    public class PersonAuth
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        /// <summary>
        /// Person id from the table of persons with personal data
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Navigation property corresponding to personId
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
