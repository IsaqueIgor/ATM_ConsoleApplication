﻿using System;

namespace ATM
{
    public class DisplayMenu : BankAccount
    {
        public void DisplayMenuOptions()
        {
            Console.WriteLine("--------------------- UCL Bank --------------------- \n\n");
            Console.WriteLine(" (1) - Withdraw Cash");
            Console.WriteLine(" (2) - Deposit Cash");
            Console.WriteLine(" (3) - Transfer Cash");
            Console.WriteLine(" (4) - Show Account Balance");
            Console.WriteLine(" (5) - Open a new Account");
            Console.WriteLine(" (6) - Exit \n \n");
            Console.WriteLine("----------------------------------------------------");

            var temp = Convert.ToInt32(Console.ReadLine());
            Choice(temp);
        }

        public void Choice(int choice)
        {
            switch (choice)
            {
                case 1:
                    DisplayWithdrawCash();
                    break;
                case 2:
                    DisplayDepositCash();
                    break;
                case 3:
                    DisplayTransfer();
                    break;
                case 4:
                    ShowAccountBalance();
                    break;
                case 5:
                    CreateAccount();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine(" \n \n  \n                                   Have a Nive day :) \n \n \n");
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine(" \n \n  \n                                   Only Admin \n \n \n");
                    OnlyAdmin();
                    break;
            }
        }

        public void DisplayWithdrawCash()
        {
            Console.Clear();
            Console.WriteLine("           $ Withdraw Cash $ \n");
            Console.WriteLine("Enter Account: ");
            this.AccountNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Cash value: ");
            decimal cash = Convert.ToDecimal(Console.ReadLine());

            if (Transaction.Withdraw(cash, AccountNumber))
            {
                DisplayMenuOptions();
            }
            else
            {
                DisplayMenuOptions();
            }
        }

        public void DisplayTransfer()
        {
            Console.Clear();
            Console.WriteLine("           $ Withdraw Cash $ \n");
            Console.WriteLine("Enter your Account: ");
            this.AccountNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Another Person Account: ");
            var target = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Cash value to Transfer: ");
            decimal cash = Convert.ToDecimal(Console.ReadLine());

            if (Transaction.Transfer(cash, this.AccountNumber, target))
            {
                DisplayMenuOptions();
            }
            else
            {
                DisplayMenuOptions();
            }
        }

        public void DisplayDepositCash()
        {
            Console.Clear();
            Console.WriteLine("           $ Deposit Cash $ \n");
            Console.WriteLine("Enter Account: ");
            this.AccountNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Cash value: ");
            decimal cash = Convert.ToDecimal(Console.ReadLine());

            if (Transaction.Deposit(cash, AccountNumber))
            {
                Console.WriteLine("Transaction Sucess \n\n");
                DisplayMenuOptions();
            }
            else
            {
                Console.WriteLine("           Something went wrong... Try again \n\n");
                DisplayMenuOptions();
            }
        }

        public void CreateAccount()
        {
            Console.Clear();
            Console.WriteLine("           $ Open New account $ \n");
            Console.WriteLine("Enter your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your 6 Numbers PIN: ");
            int pin = Convert.ToInt32(Console.ReadLine());
            BankAccount newBankAccount = new BankAccount(name, pin);

            try
            {
                DataBase.CreateAccount(newBankAccount);
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to create Account ", ex);
            }
        }

        public void ShowAccountBalance()
        {
            Console.Clear();
            Console.WriteLine("Enter Account Number: ");
            this.AccountNumber = Int32.Parse(Console.ReadLine());
            var balance = DataBase.CheckBalance(AccountNumber);
            Console.WriteLine("Account: " + AccountNumber + " | Balance: R$" + balance + "\n \n ");

            DisplayMenuOptions();
        }

        private void OnlyAdmin()
        {
            var contas = DataBase.ListBankAccounts();
            var adminsenha = 1996;

            Console.WriteLine("Enter your Admin Password: ");
            var senha = Convert.ToInt32(Console.ReadLine());

            if(senha == adminsenha)
            {
                foreach (var conta in contas)
                {
                    Console.WriteLine("\nAccount Number:" + conta.AccountNumber);
                    Console.WriteLine("Account Balance: R$" + conta.AccountBalance);
                    Console.WriteLine("------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Password Incorrect!! Contact an Admin");
            }

            
        }
    }
}