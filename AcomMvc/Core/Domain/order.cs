using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class order: authorData
    {
        public int ID { get; set; }
        [Display(Name="Codice ordine")]
        [MaxLength(32,ErrorMessage="Attenzione, codice ordine non può superare 32 caratteri")]
        public string orderCode { get; set; }
        public int orderNum { get; set; }
        [Display(Name="Codice SAP")]
        [MaxLength(32,ErrorMessage="Attenzione, codice ordine SAP non può superare 32 caratteri")]
        public string orderSap { get; set; }
        [Display(Name="Data ordine")]
        [DisplayFormat(DataFormatString="dd/MM/yyyy")]
        [Required(ErrorMessage="Inserire data ordine")]
        public DateTime orderDate { get; set; }
        [Display(Name="Importo")]
        [DisplayFormat(DataFormatString="{0:C}")]
        public Nullable<decimal> orderAmount { get; set; }
        [Display(Name="Riferimento impianto")]
        [MaxLength(255,ErrorMessage="Attenzione, riferimento impianto non può superare 255 caratteri")]
        public string orderRifImpianto { get; set; }
        [Display(Name = "Riferimento offerta")]
        [MaxLength(255, ErrorMessage = "Attenzione, riferimento offerta non può superare 255 caratteri")]
        public string orderRifOfferta { get; set; }
        [Display(Name = "Riferimento offerta esterna")]
        [MaxLength(255, ErrorMessage = "Attenzione, riferimento offerta esterna non può superare 255 caratteri")]
        public string orderRifOffertaEst { get; set; }
        [Display(Name = "Riferimento ordine cliente")]
        [MaxLength(255, ErrorMessage = "Attenzione, riferimento ordine cliente non può superare 255 caratteri")]
        public string orderRifOrdine { get; set; }

        [Display(Name="Cliente")]
        [ForeignKey("client")]
        [Required(ErrorMessage="Inserire cliente")]
        public int clientID { get; set; }
        [Display(Name = "Filiale")]
        [ForeignKey("clientOffice")]
        public Nullable<int> clientOfficeID { get; set; }
        [Display(Name = "Agente")]
        [ForeignKey("agent")]
        public Nullable<int> agentID { get; set; }

        public virtual client client { get; set; }
        public virtual clientOffice clientOffice { get; set; }
        public virtual agent agent { get; set; }

        public virtual ICollection<orderRow> orderRows { get; set; }
    }
}