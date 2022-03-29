using CodeFirst.Domain.BaseEntities;

namespace CodeFirst.Core.DTOs.Product.Responses
{
    public class ProductDtoResponse : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Images { get; set; }
    }
}
