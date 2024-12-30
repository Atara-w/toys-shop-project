using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public int PurchaseCustomerId { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public int PurchaseAmountToPay { get; set; }

    public string PurchaseMention { get; set; } = null!;

    public virtual Customer PurchaseCustomer { get; set; } = null!;

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
