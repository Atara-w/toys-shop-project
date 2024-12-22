using System.Collections.Generic;
using Dal.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dal
{
    public class products
    {
        //פונקציה שמחזירה רשימת מוצרים מקושרת לטבלאות
        public static async Task<List<Dto.productDto>> SelectAllAsync()
        {
            using (ToysShopContext db = new ToysShopContext())
            {
                var list = await db.Products
                                   .Include(p => p.ProductCategory) // טוען את הקטגוריות
                                   .Include(p => p.ProductCompany) // טוען את החברות
                                   .ToListAsync();

                // המרה ל-DTO
              return converter.productConvert.ProductConverterList(list);
            }
        }
        //סינון ע"פ קטגוריה
        public static async Task<List<Dto.productDto>> FilterByCategoriesAsync(string categoryName)
        {
            using (ToysShopContext db = new ToysShopContext())
            {
                var list = await db.Products
                                   .Include(p => p.ProductCategory) // טוען את הקטגוריות
                                   .Include(p => p.ProductCompany) // טוען את החברות
                                   .Where(p => p.ProductCategory.CategoryName.Equals(categoryName))
                                   .ToListAsync();
                return converter.productConvert.ProductConverterList(list);
            }

        }
        //סינון ע"פ מחיר
        public static async Task<List<Dto.productDto>> FilterByPriceAsync(int price)
        {
            using (ToysShopContext db = new ToysShopContext())
            {
                var list = await db.Products
                                   .Include(p => p.ProductCategory) // טוען את הקטגוריות
                                   .Include(p => p.ProductCompany) // טוען את החברות
                                   .Where(p => p.ProductPrice<=price)
                                   .ToListAsync();
                return converter.productConvert.ProductConverterList(list);
            }
        }
    }
}



