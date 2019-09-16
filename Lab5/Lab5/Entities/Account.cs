using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab5.Entities.Enums;

namespace Lab5.Entities
{
    class Account
    {
        public List<double> InitialDepositAmountList = new List<double>();
        public List<string> StatusList = new List<string>();
        
        public string Deposit()
        {
            return Enums.TransactionType.DEPOSIT.ToString();
        }

        public string Withdraw()
        {
            return Enums.TransactionType.WITHDRAW.ToString();
        }
    }
}
