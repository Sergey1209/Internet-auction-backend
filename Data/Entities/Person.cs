namespace Data.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }        
        
        public Customer Customer { get; set; }
        public Seller Seller { get; set; }
        public PersonAuth PersonAuth { get; set; }  
    }
}
