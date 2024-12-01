using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(p => p.ProductId); // Pk yapmak için kod snippet deniyor sanırım
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.HasData(
                new Product() { ProductId = 1, CategoryId = 2, ImageUrl = "~/images/1.jpeg", ProductName = "Computer", Price = 17_000, ShowCase = false },
                new Product() { ProductId = 2, CategoryId = 2, ImageUrl = "~/images/2.jpeg", ProductName = "Keyboard", Price = 1_000, ShowCase = false },
                new Product() { ProductId = 3, CategoryId = 2, ImageUrl = "~/images/3.jpeg", ProductName = "Mouse", Price = 500, ShowCase = false },
                new Product() { ProductId = 4, CategoryId = 2, ImageUrl = "~/images/4.jpeg", ProductName = "Monitor", Price = 7_000, ShowCase = false },
                new Product() { ProductId = 5, CategoryId = 2, ImageUrl = "~/images/5.jpeg", ProductName = "Deck", Price = 1_500, ShowCase = false },
                new Product() { ProductId = 6, CategoryId = 1, ImageUrl = "~/images/6.jpeg", ProductName = "History Book", Price = 25, ShowCase = false },
                new Product() { ProductId = 7, CategoryId = 1, ImageUrl = "~/images/7.jpeg", ProductName = "Hamlet", Price = 45, ShowCase = false },
                new Product() { ProductId = 8, CategoryId = 2, ImageUrl = "~/images/7.jpeg", ProductName = "Xp-Pen", Price = 45, ShowCase = true },
                new Product() { ProductId = 9, CategoryId = 2, ImageUrl = "~/images/7.jpeg", ProductName = "Samsung Galaxy FE", Price = 4445, ShowCase = true },
                new Product() { ProductId = 10, CategoryId = 1, ImageUrl = "~/images/7.jpeg", ProductName = "HP Mouse", Price = 545, ShowCase = true }

                );
        }
    }
}
