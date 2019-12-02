using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    public class DisplayMenu : BankAccount
    {
        private DataBase db;

        public DisplayMenu()
        {
            DataBase db = new DataBase();
        }

        public void DisplayBalance(decimal balance)
        {
            Console.WriteLine(this.AccountNumber + " Balance: R$"+ balance);
        }

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
        }

        public void Choice(int choice)
        {
            switch (choice)
            {
                case 1:
                    
                    break;
                case 2:
                    DisplayDepositCash();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    CreateAccount();
                    break;
                case 6:

                    break;
            }
        }

        public void DisplayDepositCash()
        {
            decimal cash = 0;
            int account = 0;
            Console.Clear();
            Console.WriteLine("           $ Deposit Cash $ \n");
            Console.WriteLine("Enter Account: ");
            account = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Cash value: ");
            cash = Convert.ToDecimal(Console.ReadLine());

            Transaction transaction = new Transaction();
            transaction.Deposit(cash, account);
        }

        public void CreateAccount()
        {
            decimal cash = 0;
            Console.Clear();
            Console.WriteLine("           $ Open New account $ \n");
            Console.WriteLine("Enter your Account: ");
            int account = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your 6 Numbers PIN: ");
            int pin = Convert.ToInt32(Console.ReadLine());

            try
            {
                db.CreateAccount(name, account, pin, cash);
                Console.WriteLine("Success");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unable to create Account");
            }
        }
    }
}