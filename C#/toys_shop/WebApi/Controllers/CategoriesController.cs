using Dal.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("getCategories")]
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await Bll.CategoriesBll.GetCategoriesAsync();
        }
    }
}
