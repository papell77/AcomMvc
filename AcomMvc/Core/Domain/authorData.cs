using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AcomMvc.Core.Domain
{
    public class authorData
    {
        [Display(Name = "Note")]
        [MaxLength(512, ErrorMessage = "Attenzione, il campo note non può superare i 512 caratteri")]
        public string note { get; set; }
        [Display(Name = "Annullato")]
        public bool annull { get; set; }

        [Display(Name = "Creato da")]
        public string createdBy { get; set; }
        [Display(Name = "Creato il")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> createdDate { get; set; }
        [Display(Name = "Aggiornato da")]
        public string updatedBy { get; set; }
        [Display(Name = "Aggiornato il")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> updatedDate { get; set; }
        [Timestamp]
        [HiddenInput(DisplayValue=false)]
        public byte[] rowvers { get; set; }

    }
}