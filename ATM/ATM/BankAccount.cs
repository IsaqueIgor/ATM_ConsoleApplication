using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATM
{
    public class BankAccount
    {
        public string Name { get; set; }

        public int AccountNumber { get; set; }

        [Range(6, 8)]
        public int Pin { get; set; }

        public decimal AccountBalance { get; set; }

        public BankAccount(string Name, int Pin)
        {
            Random rnd = new Random();
            this.Name = Name;
            this.Pin = Pin;
            AccountBalance = 0;
            this.AccountNumber = rnd.Next(10000, 99999);
        }

        public BankAccount() { } //Construtor para poder herdar no display
    }
}
