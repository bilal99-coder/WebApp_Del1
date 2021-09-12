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
        public int billettId;

        public double pris { get; set; }
        public String navn { get; set; }
        public String tidspunkt { get; set; }
        public String addresse { get; set; }
        public int type { get; set; }

        public virtual List<Lugar> lugarer { get; set; }
        public virtual List<Person> personer { get; set; }


    }
}