namespace CodeFirst.Domain.QueryFilters
{
    public class ProductQueryFilter
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
