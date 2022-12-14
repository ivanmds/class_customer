namespace Customer.Models
{
    public class CustomerEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Document { get; set; }

        public List<string> Phones { get; set; }
        public List<string> Address { get; set; }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}