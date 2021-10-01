using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.Models
{
    public class accounts
    {
        public int id { get; set; }
        public string username { get; set; }
        public int bank_id { get; set; }
        public string account_name { get; set; }
        public string account_type {get; set;}
        public int due_date { get; set; }
        public string account_no { get; set; }
        public string whereIs { get; set; }
        public float balance { get; set; }
        public string currency { get; set; }
        public string iban { get; set; }

    }
}
