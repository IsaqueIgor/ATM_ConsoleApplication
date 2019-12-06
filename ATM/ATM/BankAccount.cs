using System;
using System.ComponentModel.DataAnnotations;

namespace ATM
{
    public class BankAccount
    {
        [Required(ErrorMessage = "Please Enter your Name")]
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

        public BankAccount(int accountnum, decimal accountB)
        {
            this.AccountNumber = accountnum;
            this.AccountBalance = accountB;
        }

        public BankAccount() { } //Construtor para poder herdar no display

    }
}
