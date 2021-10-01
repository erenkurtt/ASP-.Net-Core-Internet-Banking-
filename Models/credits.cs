using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.Models
{
    public class credits
    {
        public int id { get; set; }
        public int bank_id { get; set; }
        public int amount { get; set; }
        public int repayment { get; set; }
        public int duedate { get; set; }
        public string currency { get; set; }

    }
}
