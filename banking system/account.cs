using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace account_system
{
    internal class account
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string Account_type { get; set; }
       
        public decimal Balance{ get;set; }
        public decimal Interest_rateorOverdraft_limit { get;set; }


    }
}


