using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class clientContact :authorData
    {
        public int ID { get; set; }
        [Display(Name="Nome")]
        [MaxLength(255, ErrorMessage="Attenzione, il nome non può superare 255 caratteri")]
        public string firstName { get; set; }
        [Display(Name = "Cognome")]
        [MaxLength(255, ErrorMessage = "Attenzione, il cognome non può superare 255 caratteri")]
        [Required(ErrorMessage="Inserire cognome contatto")]
        public string surname { get; set; }
        [Display(Name = "Telefono")]
        [MaxLength(64, ErrorMessage = "Attenzione, il telefono non può superare 255 caratteri")]
        [Phone]
        public string phone { get; set; }
        [Display(Name = "Cellulare")]
        [MaxLength(64, ErrorMessage = "Attenzione, il cellulare non può superare 255 caratteri")]
        [Phone]
        public string cellPhone { get; set; }
        [Display(Name = "Email")]
        [MaxLength(255, ErrorMessage = "Attenzione, email non può superare 255 caratteri")]
        [EmailAddress]
        public string email { get; set; }
        [Display(Name = "Funzione")]
        [MaxLength(255, ErrorMessage = "Attenzione, funzione non può superare 255 caratteri")]
        public string businessFunction { get; set; }
        [Display(Name = "Cliente")]
        [ForeignKey("client")]
        public Nullable<int> clientID { get; set; }
        [Display(Name = "Filiale")]
        [ForeignKey("clientOffice")]
        public Nullable<int> clientOfficeID { get; set; }

        public virtual client client { get; set; }
        public virtual clientOffice clientOffice { get; set; }
    }
}