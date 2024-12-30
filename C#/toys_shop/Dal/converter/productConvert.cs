using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converter
{
    internal class productConvert
    {
        public productConvert()
        {
            
        }
        public static Dto.productDto ProductConverter(models.Product p)
        {
            Dto.productDto list = new Dto.productDto();
            list.ProductId = p.ProductId;
            list.ProductName = p.ProductName;
            list.ProductDescription = p.ProductDescription;
            list.ProductPrice = p.ProductPrice;
            list.ProductImage = p.ProductImage;
            list.ProductLastUpdate = p.ProductLastUpdate;
            list.CategoryName = p.ProductCategory.CategoryName;
            list.CompanyName = p.ProductCompany.CompanyName;
            return list;

        }
        public static List<Dto.productDto> ProductConverterList(List<models.Product> productsList)
        {
            List<Dto.productDto> newProductList = new List<Dto.productDto>();
            foreach(var p in productsList)
            {
                newProductList.Add(ProductConverter(p));
            }
            return newProductList;
        }
    }
}
