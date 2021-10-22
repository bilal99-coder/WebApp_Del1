using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp_Del1.Models
{
    public class Billett
    {   
 
        public int BId { get; set; }
        public int Kid { get; set; }
        [RegularExpression(@"^[a-zA-zæøåÆØÅ. \-]{2,20}$")]
        public String Fornavn { get; set; }
        [RegularExpression(@"^[a-zA-zæøåÆØÅ. \-]{2,20}$")]
        public String Etternavn { get; set; }
        public String Epost { get; set; }
        public string Reisetype { get; set; }
        public string Fra { get; set; }
        public string Til { get; set; }
        public string Utreise { get; set; }
        public string Hjemreise { get; set; }
        [RegularExpression(@"^[1-9]{1}$")]
        public string AntallVoksne { get; set; }
        [RegularExpression(@"^[0-9]{1}$")]
        public string AntallBarn { get; set; }
    }
}
