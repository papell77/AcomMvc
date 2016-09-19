using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class family: authorData
    {
        public int ID { get; set; }
        [Display(Name="Famiglia")]
        [MaxLength(255, ErrorMessage="Attenzione, la descrizione non può superare 255 caratteri")]
        [Required(ErrorMessage = "Inserire descrizione")]
        [Index("IX_family", IsUnique = true)]
        public string familyDesc { get; set; }

        public virtual ICollection<pricelist> pricelists { get; set; }
    }
}