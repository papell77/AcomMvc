using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class pricelist : authorData
    {
        public int ID { get; set; }
        [Display(Name = "Codice articolo")]
        [MaxLength(64, ErrorMessage = "Attenzione, codice articolo non può superare 64 caratteri")]
        [Required(ErrorMessage="Inserire codice articolo")]
        [Index("IX_articleCode", IsUnique=true)]
        [Index("IX_articleCode_EffectiveDate", 1, IsUnique=true)]
        public string articleCode { get; set; }
        [Display(Name = "Descrizione")]
        [MaxLength(512, ErrorMessage = "Attenzione, descrizione non può superare 512 caratteri")]
        public string articleDesc { get; set; }
        [Display(Name = "Prezzo")]
        [DisplayFormat(DataFormatString="{0:C}")]
        public Nullable<decimal> articlePrice { get; set; }
        [Display(Name="Data decorrenza")]
        [DisplayFormat(DataFormatString="dd/MM/yyyy")]
        [Index("IX_articleCode_EffectiveDate", 2, IsUnique=true)]
        public Nullable<DateTime> articleEffectiveDate { get; set; }

        [ForeignKey("pricelistType")]
        public int pricelistTypeID { get; set; }
        [Display(Name="Famiglia")]
        [ForeignKey("family")]
        public Nullable<int> familyID { get; set; }
        [Display(Name="Prodotto")]
        [ForeignKey("product")]
        public Nullable<int> productID { get; set; }

        public virtual pricelistType pricelistType { get; set; }
        public virtual family family { get; set; }
        public virtual product product { get; set; }

        public virtual ICollection<offerRow> offerRows { get; set; }

    }
}