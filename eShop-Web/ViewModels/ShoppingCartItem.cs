﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eShop_Web.ViewModels;

public class ShoppingCartItem
{
    public string? Name { get; set; }
    public int Quantity { get; set; }
    [Range(1, 10000)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }
    public string? CartId { get; set;  }
}
