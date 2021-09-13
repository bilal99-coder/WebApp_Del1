using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Del1
{
    public class Person
    {
     

        [Key]
        public int personId { get; set; }

        public String fornavn { get; set; }//
        public String etternavn { get; set; }

        public String addresse { get; set; }


    }
}