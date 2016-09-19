using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AcomMvc.Core.Domain
{
    public class county : authorData
    {
        public int ID { get; set; }
        [Display(Name="Provincia")]
        [MaxLength(255, ErrorMessage="Attenzione, il nome della provincia non può superare i 255 caratteri")]
        [Required(ErrorMessage="Inserire nome provinca")]
        public string countyName { get; set; }        
        [Display(Name="Provincia")]
        [MaxLength(4, ErrorMessage="Attenzione, la sigla della provincia non può superare i 4 caratteri")]
        public string countySign { get; set; }

        //public virtual ICollection<client> clients { get; set; }
        //public virtual ICollection<clientOffice> clientOffices { get; set; }
        //public virtual ICollection<city> cities { get; set; }
    }
}