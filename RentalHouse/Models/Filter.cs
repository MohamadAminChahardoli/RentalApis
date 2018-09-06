using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalHouse.Models
{
    public class Filter
    {
        public string Zone { get; set; }
        public int FromMortgage { get; set; }
        public int ToMortgage { get; set; }
        public int FormRent { get; set; }
        public int ToRent { get; set; }
        public int Type { get; set; }
        public int Gender { get; set; }
    }
}