using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class product: authorData
    {
        public int ID { get; set; }
        [Display(Name = "prodotto")]
        [MaxLength(255, ErrorMessage = "Attenzione, la descrizione non può superare 255 caratteri")]
        [Required(ErrorMessage="Inserire descrizione")]
        [Index("IX_product", IsUnique = true)]
        public string productDesc { get; set; }

        public virtual ICollection<pricelist> pricelists { get; set; }
        public virtual ICollection<orderRow> orderRows { get; set; }


    }
}