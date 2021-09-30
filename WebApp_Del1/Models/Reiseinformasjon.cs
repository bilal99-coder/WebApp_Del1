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
        // Kun Data om Kunden som skal betale, andre pasasjerer blir representert av en annen klasse 
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int betalerId { get; set; }

        public String betalerFornavn { get; set; }//
        public String betalerEtternavn { get; set; }

        public String betalerAdresse { get; set; }
        public string betaler_kortholdersNavn { get; set; }

        public string betaler_kortNummer { get; set; }

        public int betaler_cvc { get; set; }

        // Data om lugar 
        //Jeg trenger å ha tre ulike lugarer, med 3 forskjellig Id-er. Databasen skal ha de tre lugar typer med alle data om lugarer 
        public int  LugarId { get; set;  }
        public string navn { get; set; }
        public double pris { get; set; }
        public List<Person> personer { get; set; }
    }

    public class Person
    {
        public int personId { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string adresse { get; set;  }
    }
}
