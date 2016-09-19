using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class canal:authorData
    {
        public int ID { get; set; }
        [Display(Name="Codice canale")]
        [MaxLength(32, ErrorMessage="Attenzione, il codice canale non può superare i 32 caratteri")]
        [Required(ErrorMessage="Inserire codice canale")]
        [Index("IX_canalcode", IsUnique=true)]
        public string canalCode { get; set; }
        [Display(Name="Canale")]
        [MaxLength(255, ErrorMessage="Attenzione, la descrizione canale non può superare i 255 caratteri")]
        [Required(ErrorMessage="Inserire descrizione")]
        public string canalDesc { get; set; }

        public virtual ICollection<client> clients { get; set; }
    }
}