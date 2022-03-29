using CodeFirst.Domain.Entities;
using CodeFirst.Infrastructure.Settings;

namespace CodeFirst.Infrastructure.Repositories.RespositoryAsync
{
    internal class ProductRepositoryAsync : GenericRepository<Product>
    {
        public ProductRepositoryAsync(CodeFirstContext codeFirstContext) : base(codeFirstContext)
        {

        }
    }
}
