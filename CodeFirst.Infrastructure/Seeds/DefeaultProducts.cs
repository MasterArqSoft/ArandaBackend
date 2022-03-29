using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class DefeaultProducts
    {
        public static async Task SeedDefaultProductsAsync(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Product No1",
                    Description = "Descripción No1",
                    Category = "Category No1",
                    //Images = default(byte[])
                },
                new Product()
                {
                    Id = 2,
                    Name = "Product No2",
                    Description = "Descripción No2",
                    Category = "Category No2",
                    //Images = default
                },
                new Product()
                {
                    Id = 3,
                    Name = "Product No3",
                    Description = "Descripción No3",
                    Category = "Category No3",
                    //Images = default(byte[])
                },
                new Product()
                {
                    Id = 4,
                    Name = "Product No4",
                    Description = "Descripción No4",
                    Category = "Category No4",
                    //Images = default(byte[])
                },
                new Product()
                {
                    Id = 5,
                    Name = "Product No5",
                    Description = "Descripción No5",
                    Category = "Category No5",
                    // Images = default(byte[])
                }
            );
            await Task.FromResult(Task.CompletedTask).ConfigureAwait(false);
        }
    }
}
