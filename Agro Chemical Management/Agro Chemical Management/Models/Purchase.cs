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
    public partial class Purchase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Purchase()
        {
            this.PurchaseItems = new HashSet<PurchaseItem>();
        }
        [Display(Name = "Purchase ID")]
        public int PurchaseId { get; set; }

        [Required]
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Required]
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date, ErrorMessage = "Date not valid.")]
        public System.DateTime PurchaseDate { get; set; }

        [Required]
        [Display(Name = "Party")]
        public int PartyCode { get; set; }

        [Required]
        [Display(Name = "Total Purchase Value")]
        public decimal TotalPurchaseValue { get; set; }

        [Display(Name = "Bill Type")]
        public bool BillType { get; set; }

        [Required]
        [Display(Name = "Operator Name")]
        public string Opertator { get; set; }
    
        public virtual Party Party { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
