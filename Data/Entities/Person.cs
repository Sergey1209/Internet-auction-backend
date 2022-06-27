namespace Data.Entities
{
    public class Person : BaseEntity
    {
        public string Nickname { get; set; }

        public virtual PersonAuth PersonAuth { get; set; }
    }
}
