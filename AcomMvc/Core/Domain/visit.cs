using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class visit: authorData
    {
        public int ID { get; set; }
        [Display(Name="Data")]
        [DisplayFormat(DataFormatString="dd/MM/yyyy")]
        [Required(ErrorMessage="Inserire data evento")]
        public DateTime visitDate { get; set; }
        [Display(Name="Agente")]
        [ForeignKey("agent")]
        [Required(ErrorMessage="Selezionare agente")]
        public int agentID { get; set; }
        [Display(Name="Motivo")]
        [Required(ErrorMessage="Inserire motivo")]
        public motivo visitMotivo { get; set; }
        [Display(Name="Descrizione evento")]
        [MaxLength(255,ErrorMessage="Attenzione, descrizione non può superare 255 caratteri")]
        public string visitDesc { get; set; }
        [Display(Name="Data prossimo evento")]
        [DisplayFormat(DataFormatString="dd/MM/yyyy")]
        public Nullable<DateTime> visitNextDate { get; set; }
        [Display(Name="Stato")]
        public stato stato { get; set; }

        [Display(Name="Anno")]
        public Nullable<int> visitOfferYear { get; set; }
        [Display(Name="Offerta N.")]
        [ForeignKey("offer")]
        public Nullable<int> visitOfferID { get; set; }
        [Display(Name="Ordine N.")]
        [ForeignKey("order")]
        public Nullable<int> visitOrderID { get; set; }
        [Display(Name="Cliente")]
        [ForeignKey("client")]
        public Nullable<int> clientID { get; set; }
        [Display(Name = "Filiale")]
        [ForeignKey("clientOffice")]
        public Nullable<int> clientOfficeID { get; set; }

        public virtual agent agent { get; set; }
        public virtual offer offer { get; set; }
        public virtual order order { get; set; }
        public virtual client client { get; set; }
        public virtual clientOffice clientOffice { get; set; }

    }

    public enum motivo
    {
        PubblicheRelazioni,
        Preventivo
    }

    public enum stato
    {
        Attesa,
        Rivedere,
        Concluso
    }

}