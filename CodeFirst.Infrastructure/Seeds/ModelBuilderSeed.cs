using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class ModelBuilderSeed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            Task.Run(() => DefeaultProducts.SeedDefaultProductsAsync(modelBuilder).ConfigureAwait(false));
        }
    }
}