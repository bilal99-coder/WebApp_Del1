using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Del1.Models
{
    public class Havn
    {
        [Key]
        public int HavnId { get; set; }
        public string HavnNavn { get; set; }
    }
}
/*
 
 'Property ' is not virtual. 'UseChangeTrackingProxies' requires all entity types to be public,
unsealed, have virtual properties, and have a public or protected constructor. 'UseLazyLoadingProxies' requires only the navigation properties be virtual.'
 
 
 */