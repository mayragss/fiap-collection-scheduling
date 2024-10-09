
namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Cep { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? Number { get; set; }
        public int Complement { get; set; }

        public ICollection<CollectionSchedule> CollectionExtensions { get; set; }
    }
}
