using Dal.models;
using Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpPost]
        public async Task<List<Customer>> GetCustomerByEmailAsync([FromBody] CustomerDto request)
        {
            return await Bll.CustomersBll.GetCustomerByEmailAsync(request.Email, request.Password);
        }

    }
}
