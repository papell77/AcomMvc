using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class offerRow: authorData
    {
        public int ID { get; set; }
        [Display(Name="Riga")]
        public int rigaID { get; set; }
        [Display(Name="Codice articolo")]
        [ForeignKey("article")]
        [Required(ErrorMessage="Inserire articolo")]
        public int articleID { get; set; }
        [Display(Name="Quantità")]
        [DisplayFormat(DataFormatString="{0:N2}")]
        [Required(ErrorMessage="Inserire quantità")]
        public decimal quantity { get; set; }
        [Display(Name="Prezzo")]
        [DisplayFormat(DataFormatString="{0:C}")]
        public decimal price { get; set; }
        [Display(Name="Sconto 1 %")]
        [DisplayFormat(DataFormatString="{0:N2}")]
        public Nullable<decimal> discount1 { get; set; }
        [Display(Name = "Sconto 2 %")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Nullable<decimal> discount2 { get; set; }
        [Display(Name = "Sconto 3 %")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Nullable<decimal> discount3 { get; set; }
        [Display(Name = "Sconto 4 %")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Nullable<decimal> discount4 { get; set; }
        [Display(Name = "Sconto 5 %")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Nullable<decimal> discount5 { get; set; }
        [Display(Name = "Sconto 6 %")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Nullable<decimal> discount6 { get; set; }
        [Display(Name = "Totale")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<decimal> total { get; set; }

        [ForeignKey("offer")]
        public int offerID { get; set; }

        public virtual pricelist article { get; set; }
        public virtual offer offer { get; set; }
    }
}