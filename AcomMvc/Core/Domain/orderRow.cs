using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcomMvc.Core.Domain
{
    public class orderRow: authorData
    {
        public int ID { get; set; }
        [Display(Name="Riga")]
        public int rigaID { get; set; }
        [Display(Name="Quantità")]
        public Nullable<int> orderRowQuantity { get; set; }
        [ForeignKey("order")]
        public int orderID { get; set; }
        [Display(Name="Prodotto")]
        [ForeignKey("product")]
        [Required(ErrorMessage="Inserire prodotto")]
        public int productID { get; set; }

        public virtual order order { get; set; }
        public virtual product product { get; set; }

    }
}