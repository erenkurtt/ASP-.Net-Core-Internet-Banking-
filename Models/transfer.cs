using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.Models
{
    public class transfer
    {
        public int id { get; set; }
        public string from_name { get; set; }
        public string from_no { get; set; }
        public string from_iban { get; set; }
        public string to_name { get; set; }
        public string to_no { get; set; }
        public string to_iban { get; set; }
        public float total { get; set; }
        public string date { get; set; }



    }
}
