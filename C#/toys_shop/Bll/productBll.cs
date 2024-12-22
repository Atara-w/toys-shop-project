using Dal.models;

namespace Bll
{
    public class productBll
    {
        public static async Task<List<Dto.productDto>> SelectAllAsync()
        {
            return await Dal.products.SelectAllAsync();

        }
        public static async Task<List<Dto.productDto>> FilterByCategoriesAsync(string categoryName)
        {
            return await Dal.products.FilterByCategoriesAsync(categoryName);
        }
        public static async Task<List<Dto.productDto>> FilterByPriceAsync(int price)
        {
            return await Dal.products.FilterByPriceAsync(price);
        }
    }
}
