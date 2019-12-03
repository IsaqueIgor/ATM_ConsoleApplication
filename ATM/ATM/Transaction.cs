using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    public class Transaction : BankAccount
    {
        //Deposit Cash
        public bool Deposit(Decimal value , int bankAccount)
        {
            DataBase db = new DataBase();
            try
            {
                db.SaveBalance(bankAccount, value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Transfer Cash
        public bool Transfer(Decimal value, int bankAccount)
        {

            return true;
        }

        //Withdraw
        public bool Withdraw(Decimal value, int bankAccount)
        {

            return true;
        }
    }
}
