using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class delivery : authorData //rappresenta la resa merce
    {
        public int ID { get; set; }
        [Display(Name="Resa")]
        [MaxLength(255, ErrorMessage="Attenzione, la descrizione non può superare 255 caratteri")]
        [Required(ErrorMessage="Inserire descrizione")]
        [Index("IX_delivery", IsUnique=true)]
        public string deliveryDesc { get; set; }
    }
}