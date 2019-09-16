using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Entities
{
    class SavingAccount
    {
        public double PremierAmount = 2000.0, WithdrawPenaltyAmount = 10.0;
        public double SavingBalance;
        public List<double> SavingAmountEnquiry = new List<double>();
        public List<string> SavingDateEnquiry = new List<string>();
        public List<string> SavingActivityEnquiry = new List<string>();
    }
}
