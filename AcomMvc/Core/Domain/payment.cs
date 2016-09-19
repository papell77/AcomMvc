using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class payment : authorData
    {
        public int ID { get; set; }
        [Display(Name = "Pagamento")]
        [MaxLength(255, ErrorMessage = "Attenzione, la descrizione non può superare 255 caratteri")]
        [Required(ErrorMessage="Inserire descrizione")]
        [Index("IX_payment", IsUnique = true)]
        public string paymentDesc { get; set; }
    }
}