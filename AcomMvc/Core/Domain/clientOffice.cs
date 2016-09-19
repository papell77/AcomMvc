using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class clientOffice:authorData
    {
        public int ID { get; set; }
        [Display(Name="Nome filiale")]
        [MaxLength(255, ErrorMessage="Attenzione, nome filiale non può superare i 255 caratteri")]
        [Required(ErrorMessage="Inserire nome filiale")]
        [Index("IX_clientOfficeName", IsUnique=true)]
        public string clientOfficeName { get; set; }
        [Display(Name="cap")]
        [MaxLength(5, ErrorMessage="Attenzione, cap non può superare i 5 caratteri")]
        public string clientOfficeCap { get; set; }
        [Display(Name="Indirizzo")]
        [MaxLength(255, ErrorMessage="Attenzione, indirizzo non può superare i 255 caratteri")]
        public string clientOfficeAddress { get; set; }
        [Display(Name="Telefono")]
        [MaxLength(64, ErrorMessage="Attenzione, telefono non può superare i 64 caratteri")]
        [Phone]
        public string clientOfficePhone { get; set; }
        [Display(Name = "Email")]
        [MaxLength(255, ErrorMessage = "Attenzione, email non può superare i 255 caratteri")]
        [EmailAddress]
        public string clientOfficeEmail { get; set; }

        [Display(Name = "Ragione Sociale")]
        [ForeignKey("client")]
        [Required(ErrorMessage="Inserire Ragione sociale della casa madre")]
        public int clientID { get; set; }
        [Display(Name = "Provincia")]
        [ForeignKey("county")]
        public Nullable<int> countyID { get; set; }
        [Display(Name = "Comune")]
        [ForeignKey("city")]
        public Nullable<int> cityID { get; set; }

        public virtual client client { get; set; }
        public virtual county county { get; set; }
        public virtual city city { get; set; }
        public virtual ICollection<clientContact> clientContacts { get; set; }
        public virtual ICollection<offer> offers { get; set; }
        public virtual ICollection<order> orders { get; set; }
        public virtual ICollection<visit> visits { get; set; }

    }
}