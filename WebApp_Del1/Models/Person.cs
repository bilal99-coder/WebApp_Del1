using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Del1
{
    public class Person
    {

        [Key]
        public int personId;

        public String fornavn { get; set; }
        public String etternavn { get; set; }


        public Person()
        {

        }

    }
}
© 2021 GitHub, Inc.