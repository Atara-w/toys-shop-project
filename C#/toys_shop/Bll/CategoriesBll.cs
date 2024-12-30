
using Dal.models;


namespace Bll
{
    public class CategoriesBll
    {
        public static async Task<List<Category>> GetCategoriesAsync()
        {
            return await Dal.Categories.GetCategoriesAsync();
        }
    }
}
