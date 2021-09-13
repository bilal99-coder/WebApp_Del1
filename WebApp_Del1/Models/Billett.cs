using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Del1
{
    public class Billett
    {

        [Key]
        public int billettId { get; set; }

        public double pris { get; set; }
        public String tidspunkt { get; set; }
        public int type { get; set; }

        public virtual ICollection<BillettLugar> billettLugar { get; set; }
        public virtual ICollection<BillettPerson> billettPerson { get; set; }


    }
}