using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.models;

namespace Bll
{
    public class CustomersBll
    {
        public static async Task<List<Customer>> GetCustomerByEmailAsync(string email, string password)
        {
            return await Dal.Customers.GetCustomerByEmailAsync(email, password);
        }

    }
}
