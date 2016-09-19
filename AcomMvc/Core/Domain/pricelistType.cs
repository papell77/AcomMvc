using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class pricelistType : authorData
    {
        public int ID { get; set; }
        [Display(Name="Listino")]
        [MaxLength(255, ErrorMessage="Attenzione, la descrizione non può superare 255 caratteri")]
        [Required(ErrorMessage="Inserire descrizione")]
        [Index("IX_pricelist", IsUnique=true)]
        public string pricelistDesc { get; set; }

        public virtual ICollection<pricelist> pricelists { get; set; }
        public virtual ICollection<offer> offers { get; set; }
    }
}