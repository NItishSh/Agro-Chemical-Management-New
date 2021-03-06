//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agro_Chemical_Management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class SaleItem
    {
        [Display(Name = "Sale Item ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sale ID")]
        public int SaleId { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductCode { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Tax Amount")]
        public decimal TaxAmount { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        public decimal Total { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
