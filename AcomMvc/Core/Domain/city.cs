using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class city : authorData
    {
        public int ID { get; set; }
        [Display(Name="Città")]
        [MaxLength(255, ErrorMessage="Attenzione, il nome del comune non può superare i 255 caratteri")]
        [Required(ErrorMessage="Inserire nome comune")]
        public string cityName { get; set; }
        [Display(Name = "CAP")]
        [MaxLength(5, ErrorMessage = "Attenzione, il cap non può superare i 5 caratteri")]
        [Required(ErrorMessage="Inserire cap")]
        public string cap { get; set; }
        [Display(Name="Provincia")]
        [ForeignKey("county")]
        [Required(ErrorMessage="Inserire provincia")]
        public int countyID { get; set; }

        public virtual county county { get; set; }
        //public virtual ICollection<client> clients { get; set; }
        //public virtual ICollection<clientOffice> clientOffices { get; set; }

    }
}