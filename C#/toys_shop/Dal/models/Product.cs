using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int ProductCategoryId { get; set; }

    public int ProductCompanyId { get; set; }

    public string ProductDescription { get; set; } = null!;

    public int ProductPrice { get; set; }

    public string ProductImage { get; set; } = null!;

    public DateOnly ProductLastUpdate { get; set; }

    public virtual Category ProductCategory { get; set; } = null!;

    public virtual Company ProductCompany { get; set; } = null!;

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
