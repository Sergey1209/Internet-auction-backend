namespace Data.Entities
{
    public class Person : BaseEntity
    {
        /// <summary>
        /// Nickname of registered user.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Related property with authentication data.
        /// </summary>
        public virtual PersonAuth PersonAuth { get; set; }
    }
}
