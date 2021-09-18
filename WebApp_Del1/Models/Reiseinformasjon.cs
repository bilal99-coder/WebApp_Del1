using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Del1.Models
{
    public class Reiseinformasjon
    {   //Data om ønsket billetten 
        public string reiseType { get; set; }
        public string fra { get; set; }
        public string til { get; set; }
        public DateTime utreise { get; set; }
        public int antallVoksne { get; set; }
        public int antallBarn { get; set; }
        public int antallReisende { get; set; }
        // Data om Kunden 
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int personId { get; set; }

        public String fornavn { get; set; }//
        public String etternavn { get; set; }

        public String addresse { get; set; }
        public string kortholdersNavn { get; set; }

        public string kortNummer { get; set; }

        public int cvc { get; set; }

        // Data om lugar 

        public string navn { get; set; }
        public double pris { get; set; }




    }
}
