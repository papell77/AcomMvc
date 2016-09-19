using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class client : authorData
    {
        public int ID { get; set; }
        [Display(Name = "Codice cliente")]
        [MaxLength(64, ErrorMessage = "Attenzione, il codice cliente non può superare i 64 caratteri")]
        [Required(ErrorMessage="Inserire codice cliente")]
        public string clientCode { get; set; }
        [Display(Name = "Ragione sociale")]
        [MaxLength(255, ErrorMessage = "Attenzione, la ragione sociale non può superare i 255 caratteri")]
        [Required(ErrorMessage="Inserire ragione sociale")]
        public string clientRagioneSociale { get; set; }
        [Display(Name = "Codice fiscale")]
        [MaxLength(16, ErrorMessage = "Attenzione, il codice fiscale non può superare i 16 caratteri")]
        public string clientCF { get; set; }
        [Display(Name = "P.Iva")]
        [MaxLength(11, ErrorMessage = "Attenzione, la partita iva non può superare gli 11 caratteri")]
        public string clientPiva { get; set; }
        [Display(Name = "P.Iva CEE")]
        [MaxLength(14, ErrorMessage = "Attenzione, la partita iva CEE non può superare i 14 caratteri")]
        public string clientPivaCee { get; set; }
        [Display(Name = "CAP")]
        [MaxLength(5, ErrorMessage = "Attenzione, il cap non può superare i 5 caratteri")]
        public string clientCap { get; set; }
        [Display(Name = "Indirizzo")]
        [MaxLength(512, ErrorMessage = "Attenzione, l'indirizzo non può superare i 512 caratteri")]
        public string clientAddress { get; set; }
        [Display(Name = "Telefono")]
        [MaxLength(64, ErrorMessage = "Attenzione, il telefono non può superare i 64 caratteri")]
        [Phone]
        public string clientPhone { get; set; }
        [Display(Name = "Email")]
        [MaxLength(255, ErrorMessage = "Attenzione, l'email non può superare i 255 caratteri")]
        [EmailAddress]
        public string clientEmail { get; set; }

        [Display(Name = "Invio fattura")]
        [MaxLength(64, ErrorMessage = "Attenzione, l'invio fattura non può superare i 64 caratteri")]
        public string invoiceMethod { get; set; }
        [Display(Name = "Banca")]
        [MaxLength(255, ErrorMessage = "Attenzione, il nome della banca non può superare i 255 caratteri")]
        public string bankName { get; set; }
        [Display(Name = "Iban")]
        [MaxLength(27, ErrorMessage = "Attenzione, l'iban non può superare i 27 caratteri")]
        public string ibanCode { get; set; }
        [Display(Name = "Fatturato")]
        [DisplayFormat(DataFormatString="{0:C}")]
        public Nullable<decimal> fatturato { get; set; }
        [Display(Name = "Fatturato potenziale")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<decimal> fatturatoPotenziale { get; set; }
        [Display(Name = "Fido richiesto")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<decimal> fidoRichiesto { get; set; }
        [Display(Name = "Fido concesso")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<decimal> fidoConcesso { get; set; }
        [Display(Name = "Scadenza fido")]
        [DisplayFormat(DataFormatString="dd/MM/yyyy")]
        public Nullable<DateTime> scadenzaFido { get; set; }
        [Display(Name = "Data fondazione")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public Nullable<DateTime> fondazione { get; set; }
        [Display(Name = "Possedimenti")]
        [MaxLength(512, ErrorMessage = "Attenzione, il campo possedimenti non può superare i 512 caratteri")]
        public string possedimenti { get; set; }
        [Display(Name = "Dipendenti")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public Nullable<decimal> dipendenti { get; set; }

        [Display(Name="Provincia")]
        [ForeignKey("county")]
        public Nullable<int> countyID { get; set; }
        [Display(Name = "Comune")]
        [ForeignKey("city")]
        public Nullable<int> cityID { get; set; }
        [Display(Name="Canale")]
        [ForeignKey("canal")]
        public Nullable<int> canalID { get; set; }
        [Display(Name = "Pagamento")]
        [ForeignKey("payment")]
        public Nullable<int> paymentID { get; set; }
        [Display(Name = "Trasporto")]
        [ForeignKey("shipment")]
        public Nullable<int> shipmentID { get; set; }
        [Display(Name = "Agente")]
        [ForeignKey("agent")]
        public Nullable<int> agentID { get; set; }

        public virtual ICollection<clientOffice> clientOffices { get; set; }
        public virtual ICollection<clientContact> clientContacts { get; set; }
        public virtual ICollection<order> orders { get; set; }
        public virtual ICollection<offer> offers { get; set; }
        public virtual ICollection<visit> visits { get; set; }
        public virtual county county { get; set; }
        public virtual city city { get; set; }
        public virtual canal canal { get; set; }
        public virtual payment payment { get; set; }
        public virtual shipment shipment { get; set; }
        public virtual agent agent { get; set; }

    }
}