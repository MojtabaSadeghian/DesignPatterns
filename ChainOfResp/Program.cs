﻿using System;

namespace ChainOfResp
{
    class Program
    {
        static void Main()
        {
            // Setup Chain of Responsibility
            Approver ronny = new Director();
            Approver bobby = new VicePresident();
            Approver ricky = new President();

            ronny.SetSuccessor(bobby);
            bobby.SetSuccessor(ricky);

            // Generate and process purchase requests
            Purchase p = new Purchase(8884, 350.00, "Assets");
            ronny.ProcessRequest(p);

            p = new Purchase(5675, 33390.10, "Project Poison");
            ronny.ProcessRequest(p);

            p = new Purchase(5676, 144400.00, "Project BBD");
            ronny.ProcessRequest(p);

            // Wait for user
            Console.ReadKey();
        }
    }
    abstract class Approver
    {
        protected Approver successor;
        public void SetSuccessor (Approver successor)
        {
            this.successor = successor;
        }
        public abstract void ProcessRequest(Purchase purchase);
    }

    public class Purchase
    {
        private int _number;
        private double _amount;
        private string _purpose;

        // Constructor
        public Purchase(int number, double amount, string purpose)
        {
            this._number = number;
            this._amount = amount;
            this._purpose = purpose;
        }

        // Gets or sets purchase number
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        // Gets or sets purchase amount
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        // Gets or sets purchase purpose
        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }
    }

    //The ConcreteHandler 1 class
    class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                  this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }
    //The ConcreteHandler 2 class
    class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                  this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }
    //The ConcreteHandler 3 class
    class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                  this.GetType().Name, purchase.Number);
            }
            else
            {
                Console.WriteLine(
                  "Request# {0} requires an executive meeting!",
                  purchase.Number);
            }
        }
    }
}
