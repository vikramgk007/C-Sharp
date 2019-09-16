using System;
using System.Collections;

namespace Lab4
{
    class SavingAccount
    {
        public double MonthlyDepositAmount;
        static readonly double MonthlyFee = 4.0, MonthlyInterestRate = 0.0025, MinimumInitialBalance = 1000, MinimumMonthDeposit = 50;
        //Created list to store their Owner Name, Account Number & their Balance details
        static ArrayList Ownerlist = new ArrayList();
        static ArrayList AccountNumberlist = new ArrayList();
        static ArrayList Balancelist = new ArrayList();

        public void Display()
        { 
            string Owner;
            do
            {
                int AccountNumber;
                double Amount, Balance;
                Console.Write("Enter Customer Name : ");
                Owner = Console.ReadLine();
                //If Customer Name is null display account details at end
                if (string.IsNullOrEmpty(Owner))
                {
                    goto end;
                }
                Random rnd = new Random();
                AccountNumber = rnd.Next(90000, 99999);
                Console.Write("Enter {0}'s Initial Deposit Amount (minimum $1,000.00) : ", Owner);
                Amount = double.Parse(Console.ReadLine());
                Amount: if (Amount<MinimumInitialBalance)
                {
                    Console.Write("Re-Enter {0}'s Initial Deposit Amount (minimum $1,000.00) : ", Owner);
                    Amount = double.Parse(Console.ReadLine());
                    goto Amount;
                }
                Console.Write("Enter {0}'s Monthly Deposit Amount (minimum $50.00) : ", Owner);
                MonthlyDepositAmount = double.Parse(Console.ReadLine());
                MonthlyDepositAmount: if (MonthlyDepositAmount < MinimumMonthDeposit)
                {
                    Console.Write("Re-Enter {0}'s Monthly Deposit Amount (minimum $50.00) : ", Owner);
                    MonthlyDepositAmount = double.Parse(Console.ReadLine());
                    goto MonthlyDepositAmount;
                }
                Balance = Amount;
                TotBalance(Balance);
                //Adding to the ArrayList & Storing Owner, AccountNumber & Balance
                Ownerlist.Add(Owner);
                AccountNumberlist.Add(AccountNumber);
                Balancelist.Add(TotBalance(Balance));
                goto last;
                end: Console.Write("\n");
                for (int j=0; j<Ownerlist.Count;j++)
                    Console.WriteLine("After 6 month, {0}'s account (#{1}), has a balance of : ${2}", Ownerlist[j], AccountNumberlist[j], Balancelist[j]);
                last: Console.ReadLine();
            } while (!string.IsNullOrEmpty(Owner)); //Continue still Customer Name is not null
        }

        public double Withdraw()
        {
            return MonthlyFee;
        }

        public double Deposit()
        {
            return MonthlyDepositAmount;
        }

        public double TotBalance(double Balance)
        {
            //Calculate Balance by: 1. Deducting Monthly Fee + 2. Calculating MonthlyInterestRate + 3. Adding MonthlyDepositAmount
            for (int n = 1; n <= 6; n++)
            {
                Balance = (Balance - Withdraw()) + ((Balance - Withdraw()) * MonthlyInterestRate) + Deposit();
            }
            return Balance;
        }
    }
}

