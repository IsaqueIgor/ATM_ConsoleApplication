using System;

namespace ATM
{
    public static class Transaction
    {
        //Deposit Cash
        public static bool Deposit(Decimal value , int bankAccount)
        {
            try
            {
                DataBase.SaveBalance(bankAccount, value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Transfer Cash
        public static bool Transfer(Decimal value, int bankAccount, int targetBankAccount)
        {
            var currentBalance = DataBase.CheckBalance(bankAccount);

            if (currentBalance >= value)
            {
                Deposit(value, targetBankAccount);
                DataBase.SaveBalance(bankAccount, ( value - currentBalance));
                return true;
            }
            else
            {
                Console.WriteLine(" Transfer Fail! You dont have that much money...please, Try again!");
                return false;
            }
        }

        //Withdraw
        public static bool Withdraw(Decimal value, int bankAccount)
        {
            var currentBalance = DataBase.CheckBalance(bankAccount);

            if(currentBalance >= value)
            {
                if (Deposit(value, bankAccount))
                {
                    Console.WriteLine(" Withdraw Success! Take your Money $$$$");
                    Console.WriteLine("Current Balance: R$" +DataBase.CheckBalance(bankAccount)+"\n\n");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine(" Withdraw Fail! You dont have that much money...please, Try again!");
                return false;
            }
            
        }
    }
}
