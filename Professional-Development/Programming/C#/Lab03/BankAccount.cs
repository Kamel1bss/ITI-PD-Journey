using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal class BankAccount
    {
        int accountNumber;
        double balance;
        string ownerName;
        public BankAccount(int _accountNumber = -1, string _ownerName = "UNKOWN", double _balance = 0)
        {
            accountNumber = _accountNumber;
            ownerName = _ownerName;
            balance = _balance;
        }
        public void Deposit(double _amount)
        {
            balance += _amount;
        }

        public void Withdraw(double _amount)
        {
            balance -= _amount;
        }

        public double GetBalance()
        {
            return balance;
        }

        public void Transfer(BankAccount targetAccount, double _amount)
        {
            if (balance >= _amount)
            {
                balance -= _amount;
                targetAccount.balance += _amount;
            }
        }
        public void DisplayInfo()
        {
            Console.WriteLine("========================");
            Console.WriteLine($"Account No: {accountNumber}");
            Console.WriteLine($"Owner Name: {ownerName}");
            Console.WriteLine($"Balance: {balance}");
            Console.WriteLine("========================");
        }
    }
}
