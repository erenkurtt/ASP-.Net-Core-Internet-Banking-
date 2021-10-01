using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.Models
{
    public class cards
    {
        public int id { get; set; }
        public string username { get; set; }
        public int bank_id { get; set; }
        public string card_no { get; set; }
        public int last_month { get; set; }
        public int last_year { get; set; }
        public int ccv { get; set; }
        public float limit { get; set; }
        public float debt { get; set; }
        public string currency { get; set; }


    }
}
