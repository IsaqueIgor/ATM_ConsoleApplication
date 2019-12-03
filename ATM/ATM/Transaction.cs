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
        public static bool Transfer(Decimal value, int bankAccount)
        {

            return true;
        }

        //Withdraw
        public static bool Withdraw(Decimal value, int bankAccount)
        {

            return true;
        }
    }
}
