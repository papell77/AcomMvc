using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class warranty : authorData
    {
        public int ID { get; set; }
        [Display(Name = "Garanzia")]
        [MaxLength(255, ErrorMessage = "Attenzione, la descrizione non può superare 255 caratteri")]
        [Required(ErrorMessage="Inserire descrizione")]
        [Index("IX_warranty", IsUnique = true)]
        public string warrantyDesc { get; set; }

    }
}