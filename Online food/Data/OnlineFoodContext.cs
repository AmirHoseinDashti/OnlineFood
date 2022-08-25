using Microsoft.EntityFrameworkCore;
using Online_food.Models;

namespace Online_food.Data
{
    public class OnlineFoodContext:DbContext
    {
        public OnlineFoodContext(DbContextOptions<OnlineFoodContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>().HasKey(t => new { t.ProductId, t.CategoryId });

            // modelBuilder.Entity<Product>(
            //     p =>
            //     {
            //         p.HasKey(w => w.Id);
            //         p.OwnsOne<Item>(w => w.Item);
            //         p.HasOne<Item>(w => w.Item).WithOne(w => w.Product)
            //             .HasForeignKey<Item>(w => w.Id);
            //     });

            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("int");
                i.HasKey(w => w.Id);
            });

            #region Seed Data Category

            modelBuilder.Entity<Category>().HasData(
               new Category()
               {
                   Id = 1,
                   Name = "پیتزا",
                   Description = "پیتزا"
               },
               new Category()
               {
                   Id = 2,
                   Name = "ساندویچ",
                   Description = "ساندویچ"
               },
               new Category()
               {
                   Id = 3,
                   Name = "پاستا",
                   Description = "پاستا"
               } ,
            new Category()
               {
                   Id = 4,
                   Name = "کباب",
                   Description = "کباب"
               },
               new Category()
               {
                   Id = 5,
                   Name = "غذای ایرانی",
                   Description = "غذای ایرانی"
               }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    Id = 1,
                    Price = 100000,
                    QuantityInStock = 2
                },
            new Item()
            {
                Id = 2,
                Price = 25000,
                QuantityInStock =1
            },
            new Item()
            {
                Id = 3,
                Price =15000 ,
                QuantityInStock =3
            });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                ItemId = 1,
                Name = "پیتزا قارچ",
                Description = "سس گوجه فرنگی تازه، قارچ، پنیرپیتزا"
            },
            new Product()
            {
                Id = 2,
                ItemId = 2,
                Name = "پیتزا ژامبون",
                Description = "سس گوجه فرنگی تازه، ژامبون مرغ، پنیر پیتزا"
            },
            new Product()
            {
                Id = 3,
                ItemId = 3,
                Name = "چلو کباب چنجه",
                Description = "۳۰۰ گرم مغز راسته گوسفندی، ۳۶۰ گرم برنج ایرانی، ته چین"
            });

            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() {CategoryId = 1, ProductId = 1},
                new CategoryToProduct() { CategoryId = 2, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 5, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 5, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 5, ProductId = 3 }
                );
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
