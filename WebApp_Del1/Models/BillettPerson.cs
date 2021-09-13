using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Del1
{//
    public class BillettPerson
    {

        [Key, Column(Order = 0)]
        public int billettId { get; set; }

        [Key, Column(Order = 1)]
        public int personId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Billett billett { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Person person { get; set; }
    }
}