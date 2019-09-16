using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.Entities;
using static Lab5.Entities.Enums;

namespace Lab5
{
    class Bank
    {
        static void Main(string[] args)
        {
            Customer cust = new Customer();
            Transaction trans = new Transaction();
            CheckingAccount checkacc = new CheckingAccount();
            SavingAccount savacc = new SavingAccount();
            Account acc = new Account();


            double InitialDepositAmount;
            int selection, choice;

            Console.Write("Welcome to Algonquin Bank!");
            do
            {
                try_again: Console.Write("\nEnter Customer Name: ");
                cust.CustomerName = Console.ReadLine();
                if (string.IsNullOrEmpty(cust.CustomerName))
                {
                    goto end;
                }
                Console.Write("Enter {0} Initial Deposit Amount: ", cust.CustomerName);
                InitialDepositAmount = double.Parse(Console.ReadLine());
                if (InitialDepositAmount >= savacc.PremierAmount)
                    cust.CustomerStatus = CustomerStatus.PREMIER.ToString();
                else if (InitialDepositAmount < 0)
                {
                    Console.WriteLine("Invalid Entry, Try Again!");
                    goto try_again;
                }
                else
                    cust.CustomerStatus = CustomerStatus.REGULAR.ToString();
                cust.CustomerNameList.Add(cust.CustomerName);
                acc.InitialDepositAmountList.Add(InitialDepositAmount);
                acc.StatusList.Add(cust.CustomerStatus);
            } while (!string.IsNullOrEmpty(cust.CustomerName));
        end: Console.WriteLine("");
            Console.WriteLine("Select one of the following Customers: ");
            for (int j = 0; j < cust.CustomerNameList.Count; j++)
                Console.WriteLine("{0}. Customer {1}, current status {2}", j, cust.CustomerNameList[j], acc.StatusList[j]);
            sgain: Console.Write("\nEnter your selection 0 to {0}: ",cust.CustomerNameList.Count-1);
            selection = int.Parse(Console.ReadLine());
            if (selection > cust.CustomerNameList.Count - 1)
            {
                Console.WriteLine("Invalid Entry, Try Again");
                goto sgain;
            }
            else if(selection<0)
            {
                Console.WriteLine("Invalid Entry, Try Again");
                goto sgain;
            }
            savacc.SavingBalance = Convert.ToDouble(acc.InitialDepositAmountList[selection]);
            Console.WriteLine("Welcome {0}! You are currently our {1} customer.", cust.CustomerNameList[selection], acc.StatusList[selection]);
            again: Console.WriteLine("\nSelect one of the following activities: \n 1. Deposit ...\n " +
                "2. Withdraw ...\n 3. Transfer ...\n 4. Balance Enquiry ...\n 5. Account Activity Enquiry ...\n 6. Exit ");
            Console.Write("\nEnter your selection (1 to 6): ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                case1: if (savacc.SavingBalance < savacc.PremierAmount)
                        cust.CustomerStatus = CustomerStatus.REGULAR.ToString();
                    else
                        cust.CustomerStatus = CustomerStatus.PREMIER.ToString();
                    Console.Write("\nSelect account (1 - Checking Account, 2 - Saving Acccount): ");
                    int accountselect = int.Parse(Console.ReadLine());
                    if (accountselect == 1)
                    {
                        Console.Write("\nEnter Amount: ");
                        trans.Amount = double.Parse(Console.ReadLine());
                        checkacc.CheckingBalance += trans.Amount;
                        Console.WriteLine("Deposit complete, account current balance : ${0}", checkacc.CheckingBalance);
                        checkacc.CheckingAmountEnquiry.Add(trans.Amount);
                        checkacc.CheckingDateEnquiry.Add(trans.TransactionDate);
                        checkacc.CheckingActivityEnquiry.Add(acc.Deposit());
                    }
                    else if (accountselect == 2)
                    {
                        Console.Write("\nEnter Amount: ");
                        trans.Amount = double.Parse(Console.ReadLine());
                        savacc.SavingBalance += trans.Amount;
                        Console.WriteLine("Deposit complete, account current balance : ${0}", savacc.SavingBalance);
                        savacc.SavingAmountEnquiry.Add(trans.Amount);
                        savacc.SavingDateEnquiry.Add(trans.TransactionDate);
                        savacc.SavingActivityEnquiry.Add(acc.Deposit());
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry, Try Again");
                        goto case1;
                    }
                    goto again;

                case 2:
                case2: if (savacc.SavingBalance < savacc.PremierAmount)
                        cust.CustomerStatus = CustomerStatus.REGULAR.ToString();
                    else
                        cust.CustomerStatus = CustomerStatus.PREMIER.ToString();
                    Console.Write("\nSelect account (1 - Checking Account, 2 - Saving Acccount): ");
                    accountselect = int.Parse(Console.ReadLine());
                    if (accountselect == 1)
                    {
                        Console.Write("\nEnter Amount: ");
                        trans.Amount = double.Parse(Console.ReadLine());

                        if (checkacc.CheckingBalance >= trans.Amount)
                        {
                            if (cust.CustomerStatus == CustomerStatus.REGULAR.ToString())
                            {
                                if (trans.Amount <= checkacc.MaxWithdrawAmount)
                                {
                                    checkacc.CheckingBalance -= trans.Amount;
                                    Console.WriteLine("Withdraw completed, account current balance ${0}", checkacc.CheckingBalance);
                                    checkacc.CheckingAmountEnquiry.Add(trans.Amount);
                                    checkacc.CheckingDateEnquiry.Add(trans.TransactionDate);
                                    checkacc.CheckingActivityEnquiry.Add(acc.Withdraw());
                                }
                                else
                                {
                                    Console.WriteLine("Withdraw cancelled: {0}", TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT);
                                }

                            }
                            else if (cust.CustomerStatus == CustomerStatus.PREMIER.ToString())
                            {
                                checkacc.CheckingBalance -= trans.Amount;
                                Console.WriteLine("Withdraw completed, account current balance ${0}", checkacc.CheckingBalance);
                                checkacc.CheckingAmountEnquiry.Add(trans.Amount);
                                checkacc.CheckingDateEnquiry.Add(trans.TransactionDate);
                                checkacc.CheckingActivityEnquiry.Add(acc.Withdraw());
                            }
                            else
                            {
                                Console.WriteLine("Invalid Status. Try Again..!!!");
                                goto case2;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Withdraw cancelled: {0}", TransactionResult.INSUFFICIENT_FUND);
                        }
                    }
                    else if (accountselect == 2)
                    {
                        Console.Write("\nEnter Amount: ");
                        trans.Amount = double.Parse(Console.ReadLine());
                        if (savacc.SavingBalance >= trans.Amount)
                        {
                            if (cust.CustomerStatus == "REGULAR")
                            {
                                savacc.SavingBalance -= trans.Amount;
                                savacc.SavingBalance -= savacc.WithdrawPenaltyAmount;
                                Console.WriteLine("Withdraw completed, account current balance ${0}", savacc.SavingBalance);
                                savacc.SavingAmountEnquiry.Add(trans.Amount);
                                savacc.SavingDateEnquiry.Add(trans.TransactionDate);
                                savacc.SavingActivityEnquiry.Add(TransactionType.WITHDRAW.ToString());
                                savacc.SavingAmountEnquiry.Add(savacc.WithdrawPenaltyAmount);
                                savacc.SavingDateEnquiry.Add(trans.TransactionDate);
                                savacc.SavingActivityEnquiry.Add(TransactionType.PENALTY.ToString());
                            }
                            else if (cust.CustomerStatus == "PREMIER")
                            {
                                savacc.SavingBalance -= trans.Amount;
                                Console.WriteLine("Withdraw completed, account current balance ${0}", savacc.SavingBalance);
                                savacc.SavingAmountEnquiry.Add(trans.Amount);
                                savacc.SavingDateEnquiry.Add(trans.TransactionDate);
                                savacc.SavingActivityEnquiry.Add(acc.Withdraw());
                            }
                            else
                            {
                                Console.WriteLine("Invalid Status. Try Again...!!!");
                                goto case2;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Withdraw cancelled: {0}", Enum.GetName(typeof(TransactionResult), 1));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry, Try Again");
                        goto case2;
                    }
                    goto again;

                case 3:
                case3: if (savacc.SavingBalance < savacc.PremierAmount)
                        cust.CustomerStatus = CustomerStatus.REGULAR.ToString();
                    else
                        cust.CustomerStatus = CustomerStatus.PREMIER.ToString();
                    Console.Write("\nSelect account (1 - from Checking to Saving, 2 - from Saving to Checking): ");
                    accountselect = int.Parse(Console.ReadLine());
                    if (accountselect == 1)
                    {
                        Console.Write("\nEnter Amount: ");
                        trans.Amount = double.Parse(Console.ReadLine());
                        if (checkacc.CheckingBalance >= trans.Amount)
                        {
                            checkacc.CheckingBalance -= trans.Amount;
                            savacc.SavingBalance += trans.Amount;
                            Console.WriteLine("Transfer completed, account current balance ${0}", checkacc.CheckingBalance);
                            checkacc.CheckingAmountEnquiry.Add(trans.Amount);
                            checkacc.CheckingDateEnquiry.Add(DateTime.Now.ToString("d/MM/yyyy"));
                            checkacc.CheckingActivityEnquiry.Add(TransactionType.TRANSFER_OUT.ToString());
                            savacc.SavingAmountEnquiry.Add(trans.Amount);
                            savacc.SavingDateEnquiry.Add(DateTime.Now.ToString("d/MM/yyyy"));
                            savacc.SavingActivityEnquiry.Add(TransactionType.TRNASFER_IN.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Transfer cancelled: {0}", TransactionResult.INSUFFICIENT_FUND);
                        }
                    }
                    else if (accountselect == 2)
                    {
                        Console.Write("\nEnter Amount: ");
                        trans.Amount = double.Parse(Console.ReadLine());
                        if (savacc.SavingBalance >= trans.Amount)
                        {
                            savacc.SavingBalance -= trans.Amount;
                            checkacc.CheckingBalance += trans.Amount;
                            Console.WriteLine("Transfer completed, account current balance ${0}", savacc.SavingBalance);
                            savacc.SavingAmountEnquiry.Add(trans.Amount);
                            savacc.SavingDateEnquiry.Add(DateTime.Now.ToString("d/MM/yyyy"));
                            savacc.SavingActivityEnquiry.Add(TransactionType.TRANSFER_OUT.ToString());
                            checkacc.CheckingAmountEnquiry.Add(trans.Amount);
                            checkacc.CheckingDateEnquiry.Add(DateTime.Now.ToString("d/MM/yyyy"));
                            checkacc.CheckingActivityEnquiry.Add(TransactionType.TRNASFER_IN.ToString());
                        }
                        else
                            Console.WriteLine("Transfer cancelled: {0}", TransactionResult.INSUFFICIENT_FUND);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry, Try Again");
                        goto case3;
                    }
                    goto again;

                case 4:
                    if (savacc.SavingBalance < savacc.PremierAmount)
                        cust.CustomerStatus = CustomerStatus.REGULAR.ToString();
                    else
                        cust.CustomerStatus = CustomerStatus.PREMIER.ToString();
                    Console.WriteLine("Current Balance:");
                    Console.WriteLine("\n\t Account \t\t\t Balance");
                    Console.WriteLine("\t ------- \t\t\t -------");
                    Console.WriteLine("\t Checking \t\t\t {0}", checkacc.CheckingBalance);
                    Console.WriteLine("\t Saving \t\t\t {0}", savacc.SavingBalance);
                    goto again;

                case 5:
                    if (savacc.SavingBalance < savacc.PremierAmount)
                        cust.CustomerStatus = CustomerStatus.REGULAR.ToString();
                    else
                        cust.CustomerStatus = CustomerStatus.PREMIER.ToString();
                    Console.WriteLine("\nChecking Account:");
                    Console.WriteLine("\n\t Amount \t Date \t\t Activity");
                    Console.WriteLine("\t ------ \t ---- \t\t --------");
                    for (int i = 0; i < checkacc.CheckingAmountEnquiry.Count; i++)
                        Console.WriteLine("\t {0} \t\t {1} \t {2}", checkacc.CheckingAmountEnquiry[i], checkacc.CheckingDateEnquiry[i], checkacc.CheckingActivityEnquiry[i]);
                    Console.WriteLine("\nSaving Account:");
                    Console.WriteLine("\n\t Amount \t Date \t\t Activity");
                    Console.WriteLine("\t ------ \t ---- \t\t --------");
                    for (int i = 0; i < savacc.SavingAmountEnquiry.Count; i++)
                        Console.WriteLine("\t {0} \t\t {1} \t {2}", savacc.SavingAmountEnquiry[i], savacc.SavingDateEnquiry[i], savacc.SavingActivityEnquiry[i]);

                    goto again;
                case 6:
                    break;
                default:
                    Console.WriteLine("Invalid Entry, Try Again!");
                    goto again;
            }
        }
    }
}
