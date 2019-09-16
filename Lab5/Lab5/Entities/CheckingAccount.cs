using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Entities
{
    class CheckingAccount
    {
        public double CheckingBalance = 0;
        public double MaxWithdrawAmount = 300;
        public List<double> CheckingAmountEnquiry = new List<double>();
        public List<string> CheckingDateEnquiry = new List<string>();
        public List<string> CheckingActivityEnquiry = new List<string>();
    }
}
