using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class agent : authorData
    {
        public int ID { get; set; }
        [Display(Name="Agente")]
        [Required(ErrorMessage="Inserire nome agente")]
        [MaxLength(255, ErrorMessage="Il nome dell'agente non può superare i 255 caratteri")]
        [Index("IX_agentName",IsUnique=true)]
        public string agentName { get; set; }
        [Display(Name = "Utente")]
        [ForeignKey("agentUser")]
        [Required(ErrorMessage="Inserire username riferito all'agente")]
        public string agentUserID { get; set; }

        public virtual ICollection<client> clients { get; set; }
        public virtual ICollection<offer> offers { get; set; }
        public virtual ICollection<order> orders { get; set; }
        public virtual ICollection<visit> visits { get; set; }
        public virtual ApplicationUser agentUser { get; set; }
        

    }
}