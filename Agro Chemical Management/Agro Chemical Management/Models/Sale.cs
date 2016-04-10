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
    public partial class Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            this.SaleItems = new HashSet<SaleItem>();
        }
        [Display(Name = "Sale Id")]
        public int SaleId { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Customer Address")]
        public string CustomerAddress { get; set; }

        [Required]
        [Display(Name = "Sale Date")]
        [DataType(DataType.Date, ErrorMessage = "Date not valid.")]
        public System.DateTime SaleDate { get; set; }

        [Required]
        [Display(Name = "Total Sale Value")]
        public decimal TotalSaleValue { get; set; }
        
        [Display(Name = "Sale Type")]
        public bool SaleType { get; set; }

        [Required]
        [Display(Name = "Operator Name")]
        public string Operator { get; set; }

        [Display(Name = "Sale Items")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleItem> SaleItems { get; set; }
    }
}
