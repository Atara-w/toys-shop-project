﻿using System.Collections.Generic;
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
        ////סינון ע"פ קטגוריה
        ////הפונקציה מקבלת מערך מספרים
        //public static async Task<List<Dto.productDto>> FilterByCategoriesAsync(int[] categoriesIds)
        //{
        //    using (ToysShopContext db = new ToysShopContext())
        //    {
        //        var list = await db.Products
        //                           .Include(p => p.ProductCategory) // טוען את הקטגוריות
        //                           .Include(p => p.ProductCompany) // טוען את החברות
        //                           //שהוא קיבל idבתנאי זה הוא שולף את הקטגוריות לפי מערך ה
        //                           .Where(p => categoriesIds.Contains(p.ProductCategoryId))
        //                           .ToListAsync();
        //        return converter.productConvert.ProductConverterList(list);
        //    }

        //}
        ////סינון ע"פ מחיר
        //public static async Task<List<Dto.productDto>> FilterByPriceAsync(int price)
        //{
        //    using (ToysShopContext db = new ToysShopContext())
        //    {
        //        var list = await db.Products
        //                           .Include(p => p.ProductCategory) // טוען את הקטגוריות
        //                           .Include(p => p.ProductCompany) // טוען את החברות
        //                           .Where(p => p.ProductPrice<=price)
        //                           .ToListAsync();
        //        return converter.productConvert.ProductConverterList(list);
        //    }
        //}


        public static async Task<List<Dto.productDto>> Filters(int[] categoriesIds, int? price)
        {

            using (ToysShopContext db = new ToysShopContext())
            {
                var query = db.Products
                                   .Include(p => p.ProductCategory) // טוען את הקטגוריות
                                   .Include(p => p.ProductCompany) // טוען את החברות
                                   .AsQueryable();
                if (categoriesIds != null && categoriesIds.Any())
                {
                    query = query.Where(p => categoriesIds.Contains(p.ProductCategoryId));
                }
                if (price.HasValue)
                {
                    query = query.Where(p => p.ProductPrice <= price);

                }
                var list = await query.ToListAsync();
                return converter.productConvert.ProductConverterList(list);
            }
        }
    }
}



