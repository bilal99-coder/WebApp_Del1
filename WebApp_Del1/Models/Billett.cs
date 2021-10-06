using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp_Del1.Models
{
    public class Billett
    {
        public int Kid { get; set; }
        public String Fornavn { get; set; }
        public String Etternavn { get; set; }
        public String Epost { get; set; }

        public int BId { get; set; }
        public string Reisetype { get; set; }
        public string Fra { get; set; }
        public string Til { get; set; }
        public string Utreise { get; set; }
        public string Hjemreise { get; set; }
        public string AntallVoksne { get; set; }
        public string AntallBarn { get; set; }
    }
}
