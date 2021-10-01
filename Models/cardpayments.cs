using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.Models
{
    public class cardpayments
    {
        public int id { get; set; }
        public string username { get; set; }
        public int bank_id { get; set; }
        public string card_no { get; set; }
        public float cost { get; set; }
        public string to_where { get; set; }
        public string date { get; set; }

    }
}
