using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Entities
{
    class Transaction
    {
        public double Amount;
        public string TransactionDate = DateTime.Now.ToString("d/MM/yyyy");
    }
}
