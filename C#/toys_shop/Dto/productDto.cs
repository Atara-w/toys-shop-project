namespace Dto
{
    public class productDto
    {

        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

       public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }

        //public int ProductCompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ProductDescription { get; set; } = null!;

        public int ProductPrice { get; set; }

        public string ProductImage { get; set; } = null!;

        public DateOnly ProductLastUpdate { get; set; }

    }
}
