using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class PurchaseDetail
{
    public int PurchaseDetailsId { get; set; }

    public int PurchaseDetailsPurchaseId { get; set; }

    public int PurchaseDetailsProductsId { get; set; }

    public int PurchaseDetailsAmount { get; set; }

    public virtual Product PurchaseDetailsProducts { get; set; } = null!;

    public virtual Purchase PurchaseDetailsPurchase { get; set; } = null!;
}
