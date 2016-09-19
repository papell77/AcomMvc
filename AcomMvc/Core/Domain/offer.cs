using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class offer: authorData
    {
        public int ID { get; set; }
        public int offerNum { get; set; }
        public int offerVers { get; set; }
        [Index("IX_offerCode",IsUnique=true)]
        [MaxLength(32, ErrorMessage="Attenzione, codice offerta non può superare 32 caratteri")]
        public string offerCode { get; set; }
        [Display(Name="Offerta esterna")]
        [MaxLength(32, ErrorMessage="Attenzione, codice offerta non può superare 32 caratteri")]
        public string offerEst { get; set; }
        [Display(Name="Data")]
        [Required(ErrorMessage="Inserire data offerta")]
        [DisplayFormat(DataFormatString="dd/MM/yyyy")]
        public DateTime offerDate { get; set; }
        [Display(Name="Data validità")]
        [Required(ErrorMessage="Inserire data validità")]
        [DisplayFormat(DataFormatString="dd/MM/yyyy")]
        public DateTime offerExpiryDate { get; set; }
        [Display(Name="Riferimento")]
        [MaxLength(255, ErrorMessage="Attenzione, riferimento non può superare 255 caratteri")]
        public string offerReference { get; set; }
        [Display(Name="Stato")]
        [Required(ErrorMessage="Selezionare uno stato dell'offerta")]
        public offerState offerState { get; set; }
        [Display(Name="Importo")]
        [DisplayFormat(DataFormatString="{0:C}")]
        public Nullable<decimal> offerAmount { get; set; }
        [Display(Name = "Costo di trasporto")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<decimal> offerShippingCost { get; set; }
        [Display(Name = "Tempi di consegna")]
        [MaxLength(255, ErrorMessage="Attenzione, tempi di consegna non può superare 255 caratteri")]
        public string offerDeliveryTime { get; set; }
        [Display(Name = "Imballo")]
        [MaxLength(255, ErrorMessage = "Attenzione, imballo non può superare 255 caratteri")]
        public string offerPackaging { get; set; }
        
        [Display(Name="Listino")]
        [ForeignKey("pricelistType")]
        [Required(ErrorMessage="Selezionare listino")]
        public int pricelistTypeID { get; set; }
        [Display(Name="Cliente")]
        [ForeignKey("client")]
        [Required(ErrorMessage="Selezionare cliente")]
        public int clientID { get; set; }
        [Display(Name = "Filiale")]
        [ForeignKey("clientOffice")]
        public Nullable<int> clientOfficeID { get; set; }
        [Display(Name = "Famiglia")]
        [ForeignKey("family")]
        public Nullable<int> familyID { get; set; }
        [Display(Name = "Agente")]
        [ForeignKey("agent")]
        public Nullable<int> agentID { get; set; }
        [Display(Name = "Contatto")]
        [ForeignKey("clientContact")]
        public Nullable<int> clientContactID { get; set; }
        [Display(Name = "Pagamento")]
        [ForeignKey("payment")]
        public Nullable<int> paymentID { get; set; }
        [Display(Name = "Trasporto")]
        [ForeignKey("shipment")]
        public Nullable<int> shipmentID { get; set; }
        [Display(Name = "Resa")]
        [ForeignKey("delivery")]
        public Nullable<int> deliveryID { get; set; }
        [Display(Name = "Garanzia")]
        [ForeignKey("warranty")]
        public Nullable<int> warrantyID { get; set; }

        public virtual pricelistType pricelistType { get; set; }
        public virtual client client { get; set; }
        public virtual clientOffice clientOffice { get; set; }
        public virtual family family { get; set; }
        public virtual agent agent { get; set; }
        public virtual clientContact clientContact { get; set; }
        public virtual payment payment { get; set; }
        public virtual shipment shipment { get; set; }
        public virtual delivery delivery { get; set; }
        public virtual warranty warranty { get; set; }

        public virtual ICollection<offerRow> offerRows { get; set; }

    }

    public enum offerState
    {
        Attesa,
        Vinta,
        Persa,
        Aggiornata
    }

}