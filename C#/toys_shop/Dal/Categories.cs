using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.models;
using Microsoft.EntityFrameworkCore;


namespace Dal
{
    public class Categories
    {
        public static async Task<List<Category>> GetCategoriesAsync()
        {
            using (ToysShopContext db = new ToysShopContext())
            {
                var list = await db.Categories.ToListAsync();

                return list;
            }
        }
    }
}
