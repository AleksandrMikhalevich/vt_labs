using Microsoft.EntityFrameworkCore;
using Mikhalevich20331.ZooshopDomain.Entities;

namespace Mikhalevich20331.API.Data
{
    public class DbInitializer
    {
        public static async Task SeedData(WebApplication app)
        {          
            // Получение контекста БД
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            //Выполнение миграций
            await context.Database.MigrateAsync();

            if (!context.Categories.Any() && !context.Products.Any())
            {
                var _categories = new Category[]
            {
            new Category {GroupName="Поводки",
            NormalizedName="Поводки"},
            new Category {GroupName="Одежда",
            NormalizedName="Одежда"},
            new Category {GroupName="Игрушки",
            NormalizedName="Игрушки"}
            };

            await context.Categories.AddRangeAsync(_categories);
            await context.SaveChangesAsync();

            var _products = new List<Product>
            {
            new Product { Name = "Поводок 7 м",
                Description = "Поводок вытяжной 7 м (рулетка)",
                Image = "../images/leash2.jpg",
                Category = _categories.FirstOrDefault(c => c.NormalizedName.Equals("Поводки")) },

            new Product { Name = "Поводок 5 м",
                Description = "Поводок брезентовый 5 м",
                Image = "../images/leash1.jpg",
                Category = _categories.FirstOrDefault(c => c.NormalizedName.Equals("Поводки")) },


            new Product { Name = "Платок на шею 30x30",
                Description = "Платок на шею 30x30 красный (хлопок)",
                Image = "../images/neck_scarf.jpg",
                Category = _categories.FirstOrDefault(c => c.NormalizedName.Equals("Одежда")) },


            new Product { Name = "Костюм для собак до 35 см",
                Description = "Костюм для собак до 35 см синий (полиэстер)",
                Image = "../images/costume.jpg",
                Category = _categories.FirstOrDefault(c => c.NormalizedName.Equals("Одежда")) },


            new Product { Name = "Игрушка-кольцо",
                Description = "Игрушка-кольцо силиконовое для собак",
                Image = "../images/toy1.jpg",
                Category = _categories.FirstOrDefault(c => c.NormalizedName.Equals("Игрушки")) },

            new Product { Name = "Набор игрушек",
                Description = "Набор игрушек тканевых для собак в ассортименте",
                Image = "../images/toy2.jpg",
                Category = _categories.FirstOrDefault(c => c.NormalizedName.Equals("Игрушки")) },
            };

            await context.Products.AddRangeAsync(_products);
            await context.SaveChangesAsync();

            }
        }
    }
}

