using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billetter.Model
{
    public class Lugar
    {
        public String bildeURL { get; set; }
        public String beskrivelse { get; set; }

        public bool harWc { get; set; }
        public String wciIconURL { get; set; }

        public bool harDysj { get; set; }
        public String dysjIconURL { get; set; }

        public bool harWifi { get; set; }
        public String wifiIconURL { get; set; }

        public int antPlasser { get; set; }
        public String plassIconURL { get; set; }


        public String pris { get; set; }
        public String prisURL { get; set; }


    }
}