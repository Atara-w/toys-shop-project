using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dal.models;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class Customers
    {


        public static async Task<List<Customer>> GetCustomerByEmailAsync(string email, string password)
        {
            using (ToysShopContext db = new ToysShopContext())
            {
                var customer = await db.Customers
                                    .Where(c => c.CustomerEmail.Equals(email) && c.CustomerPassword.Equals(password))
                                    .ToListAsync();
                if (customer != null && customer.Any())
                {
                    return customer;
                }
                else
                {
                    throw new Exception("Incorrect email or password");
                }
            }

        }
    }
}
