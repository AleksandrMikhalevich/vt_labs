using Mikhalevich20331.ZooshopDomain.Entities;
using Mikhalevich20331.ZooshopDomain.Models;

namespace Mikhalevich20331.UI.Services
{
    public class MemoryCategoryService : ICategoryService
    {
        public Task<ResponseData<List<Category>>> GetCategoryListAsync()
        {
            var categories = new List<Category>
        {
        new Category {Id=1, GroupName="Поводки",
        NormalizedName="Поводки для собак"},
        new Category {Id=2, GroupName="Одежда",
        NormalizedName="Одежда  для собак"},
        new Category {Id=2, GroupName="Игрушки",
        NormalizedName="Игрушки для собак"}

        };
            var result = new ResponseData<List<Category>>();
            result.Data = categories;
            return Task.FromResult(result);
        }
    }
}
