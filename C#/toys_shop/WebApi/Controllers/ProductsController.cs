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
        [HttpGet("category filter")]
        public async Task<List<Dto.productDto>> FilterByCategoriesAsync(string categoryName)
        {
            return await Bll.productBll.FilterByCategoriesAsync(categoryName);
        }
        [HttpGet("price filter")]
        public async Task<List<Dto.productDto>> FilterByPriceAsync(int price)
        {
            return await Bll.productBll.FilterByPriceAsync(price);
        }

    }
}
