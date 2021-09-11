using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Del1
{
    public class Billett
    {
        public double pris { get; set; }
        public String navn { get; set; }
        public DateTime tidspunkt { get; set; }
        public String addresse { get; set; }
        public int type { get; set; }
        public int lugarId { get; set; }

        public Billett()
        {

        }

    }
}