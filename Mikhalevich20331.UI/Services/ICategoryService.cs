using Mikhalevich20331.ZooshopDomain.Entities;
using Mikhalevich20331.ZooshopDomain.Models;

namespace Mikhalevich20331.UI.Services
{
    public interface ICategoryService
    {
        /// <summary>
        /// Получение списка всех категорий
        /// </summary>
        /// <returns></returns>
        public Task<ResponseData<List<Category>>> GetCategoryListAsync();
    }
}
