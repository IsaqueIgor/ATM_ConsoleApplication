using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    public class DisplayMenu : BankAccount
    {
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
            Console.WriteLine(" (5) - Exit \n \n");
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
        }

    }
}