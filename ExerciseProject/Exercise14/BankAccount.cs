using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProject.Exercise14
{
    public class BankAccount
    {
        public string Name { get; set; }
        public double Balance { get; private set; }

        bool locked;

        public BankAccount (string name, double balance, bool locked) { 
            Name = name;
            Balance = balance;

            this.locked = locked;
        }

        public BankAccount (string name, double balance) : this (name, balance, false) { 
            Name = name;
            Balance = balance;
        }

        public BankAccount (double balance) : this ("", balance, false) {
            Balance = balance;
        }

        public void Deposit (double amount) {
            if (!locked) { 
                Balance += amount;
            }
        }

        public void Withdraw (double amount) {
            if (!locked && amount <= Balance) {
                Balance -= amount;
            }
        }

        public void ChangeLockState () {
            locked = !locked;
        }

        public override string ToString () {
            return "Name: " + Name + ", Balance: " + Balance;
        }
    }
}
