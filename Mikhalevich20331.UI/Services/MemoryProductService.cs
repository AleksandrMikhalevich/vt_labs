using Microsoft.AspNetCore.Mvc;
using Mikhalevich20331.ZooshopDomain.Entities;
using Mikhalevich20331.ZooshopDomain.Models;

namespace Mikhalevich20331.UI.Services
{
    public class MemoryProductService : IProductService
    {
        List<Product> _products;
        List<Category> _categories;
        IConfiguration _config;

        public MemoryProductService(ICategoryService categoryService, [FromServices] IConfiguration config)
        {
            _config = config;
            _categories = categoryService.GetCategoryListAsync()
                .Result
                .Data;

            SetupData();
        }

        /// <summary>
        /// Инициализация списков
        /// </summary>
        public void SetupData()
        {

            _products = new List<Product>
        {
            new Product { Id = 1, Name = "Поводок 7 м",
                Description = "Поводок вытяжной 7 м (рулетка)",
                Image = "../images/leash2.jpg",
                CategoryId = _categories.Find(c => c.NormalizedName.Equals("Поводки")).Id },

            new Product { Id = 2, Name = "Поводок 5 м",
                Description = "Поводок брезентовый 5 м",
                Image = "../images/leash1.jpg",
                CategoryId = _categories.Find(c => c.NormalizedName.Equals("Поводки")).Id },


            new Product { Id = 3, Name = "Платок на шею 30x30",
                Description = "Платок на шею 30x30 красный (хлопок)",
                Image = "../images/neck_scarf.jpg",
                CategoryId = _categories.Find(c => c.NormalizedName.Equals("Одежда")).Id },


            new Product { Id = 4, Name = "Костюм для собак до 35 см",
                Description = "Костюм для собак до 35 см синий (полиэстер)",
                Image = "../images/costume.jpg",
                CategoryId = _categories.Find(c => c.NormalizedName.Equals("Одежда")).Id },


            new Product { Id = 5, Name = "Игрушка-кольцо",
                Description = "Игрушка-кольцо силиконовое для собак",
                Image = "../images/toy1.jpg",
                CategoryId = _categories.Find(c => c.NormalizedName.Equals("Игрушки")).Id },

            new Product { Id = 6, Name = "Набор игрушек",
                Description = "Набор игрушек тканевых для собак в ассортименте",
                Image = "../images/toy2.jpg",
                CategoryId = _categories.Find(c => c.NormalizedName.Equals("Игрушки")).Id }

        };
        }

        Task<ResponseData<ProductListModel<Product>>> IProductService.GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
        {

            // Создать объект результата
            var result = new ResponseData<ProductListModel<Product>>();

            // Id категории для фильрации
            int? categoryId = null;

            // если требуется фильтрация, то найти Id категории
            // с заданным categoryNormalizedName
            if (categoryNormalizedName != null)
                categoryId = _categories
                .Find(c =>
                c.NormalizedName.Equals(categoryNormalizedName))
                ?.Id;

            // Выбрать объекты, отфильтрованные по Id категории,
            // если этот Id имеется
            var data = _products
            .Where(d => categoryNormalizedName == null || d.CategoryId.Equals(categoryId))?
            .ToList();

            // получить размер страницы из конфигурации
            int pageSize = _config.GetSection("ItemsPerPage").Get<int>();

            // получить общее количество страниц
            int totalPages = (int)Math.Ceiling(data.Count / (double)pageSize);

            // получить данные страницы
            var listData = new ProductListModel<Product>()
            {
                Items = data.Skip((pageNo - 1) *
            pageSize).Take(pageSize).ToList(),
                CurrentPage = pageNo,
                TotalPages = totalPages
            };

            // поместить ранные в объект результата
            result.Data = listData;


            // Если список пустой
            if (data.Count == 0)
            {
                result.Success = false;
                result.ErrorMessage = "Нет объектов в выбраннной категории";
            }
            // Вернуть результат
            return Task.FromResult(result);

        }

        public Task<ResponseData<Product>> CreateProductAsync(Product product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<Product>> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task UpdateProductAsync(int id, Product product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }
    }
}
