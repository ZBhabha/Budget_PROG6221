using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Budget
{ // inherits from parent class Expense
    class Vehicle : Expense
   
    {  //Variables declared
        private string modelMake;
        private double purchPrice;
        private double deposit;
        private double interest;
        double insurance;
        double loanRepayment;

        //constructor created
        public Vehicle(string modelMake, double purchPrice, double deposit, double interest, double insurance,string name, double amount) : base(name,amount)
        {
            this.modelMake = modelMake;
            this.purchPrice = purchPrice;
            this.deposit = deposit;
            this.interest = interest;
            this.insurance = insurance;
        }

        // getters and setters
        public string ModelMake { get => modelMake; set => modelMake = value; }
        public double PurchPrice { get => purchPrice; set => purchPrice = value; }
        public double Deposit { get => deposit; set => deposit = value; }
        public double Interest { get => interest; set => interest = value; }
        public double Insurance { get => insurance; set => insurance = value; }
        public double LoanRepayment { get => loanRepayment; set => loanRepayment = value; }

        //Method to calculate monthly car loan repayment
        public double calc()
        {
            double percentage =  interest/ 100;
            double pAmount = purchPrice - deposit;
            double total = pAmount * (1 + percentage * 5);
            double monthly = total / 60;
            loanRepayment = monthly + insurance;

            return loanRepayment;

        }
        //Method to inform user regarding how much they will have to paymonthly for the car loan as well as display
        //available monthly money after all expenses including loans are deducted
        public void vehicleAlert()
        {
            double sum = ListUtil.expList.Sum(i => i.Amount);
            double net = Helper.income - sum;
            net = Math.Round((Double)net, 2);
            MessageBox.Show("You have to pay R" + Helper.loanRepayment.ToString() + " monthly for 5 years\nAvailable Monthly Money : R"+net.ToString(), "Car Loan Repayment", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
      
}
