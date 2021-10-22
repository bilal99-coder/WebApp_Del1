using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Del1.DAL;

namespace WebApp_Del1.Models
{
    public class Havn
    {
        [Key]
        public int HavnId { get; set; }
        public string HavnNavn { get; set; }
        public virtual List<ankomstHavner> AnkomstHavner { get; set; }
    }
}
