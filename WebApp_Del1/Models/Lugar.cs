﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Del1
{
    public class Lugar
    {

        public Lugar(String bildeURL, String beskrivelse)
        {
            this.bildeURL = bildeURL;
            this.beskrivelse = beskrivelse;
        }

        public String bildeURL { get; set; }
        public String beskrivelse { get; set; }

       // public bool harWc { get; set; }
       // public String wciIconURL { get; set; }

       // public bool harDysj { get; set; }
       // public String dysjIconURL { get; set; }

       // public bool harWifi { get; set; }
       // public String wifiIconURL { get; set; }

      //  public int antPlasser { get; set; }
      //  public String plassIconURL { get; set; }


       // public String pris { get; set; }
      //  public String prisIconURL { get; set; }


    }
}