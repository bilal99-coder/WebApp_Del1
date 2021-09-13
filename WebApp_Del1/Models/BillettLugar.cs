using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//
namespace WebApp_Del1
{
    public class BillettLugar
    {

        [Key, Column(Order = 0)]
        public int billettId { get; set; }

        [Key, Column(Order = 1)]
        public int lugarId { get; set; }
  
        public virtual Billett billett { get; set; }

        public virtual Lugar lugar { get; set; }

    }
}