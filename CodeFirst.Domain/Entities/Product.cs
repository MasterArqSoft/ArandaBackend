using CodeFirst.Domain.BaseEntities;

namespace CodeFirst.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public byte[] Images { get; set; }
    }
}
