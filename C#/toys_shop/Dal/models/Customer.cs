﻿using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public string CustomerPassword { get; set; } = null!;

    public DateOnly CustomerDateOfBirth { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
