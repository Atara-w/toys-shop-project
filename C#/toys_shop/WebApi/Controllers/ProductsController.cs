using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Dto.productDto>> GetProducts()
        {
            return await Bll.productBll.SelectAllAsync();
        }
        //postל HTTPשינוי ה
        [HttpPost("categoryFilter")]
        //לכך שהיא מקבלת מערך מספרים DALשינוי הפונקציה ב
        public async Task<List<Dto.productDto>> FilterByCategoriesAsync(int[] categoriesIds)
        {
            return await Bll.productBll.FilterByCategoriesAsync(categoriesIds);
        }

        [HttpPost("priceFilter")]
        public async Task<List<Dto.productDto>> FilterByPriceAsync(int price)
        {
            return await Bll.productBll.FilterByPriceAsync(price);
        }

    }
}
