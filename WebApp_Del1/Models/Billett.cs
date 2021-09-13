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
        public Billett()
        {
           // this.personer = new HashSet<Person>();
           // this.lugarer = new HashSet<Lugar>();
        }

        [Key]
        public int billettId { get; set; }

        public double pris { get; set; }
        public String tidspunkt { get; set; }
        public int type { get; set; }

        public virtual List<BillettPerson> billettPerson { get; set; }
        public virtual List<BillettLugar> billettLugar { get; set; }

        public virtual ICollection<Person> personer { get; set; }
        public virtual ICollection<Lugar> lugarer { get; set; }
    }
}