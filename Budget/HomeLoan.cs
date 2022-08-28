using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Budget
{
    class HomeLoan : Expense
        
     //inheritence-Expense class is the base class,HomeLoan is the child class
    {
    // variables declared
       private double price;
       private double percentage;
       private double deposit;
       private double numOfMonths;
       private double repayment;

        


        //Constructor created
        //I used the MenuApp made in class as a reference on how to make a constructor with parent class included.
        public HomeLoan(double price, double percentage, double deposit, double numOfMonths,string name,double amount) : base(name,amount)
        { 
            this.price = price;
            this.percentage = percentage;
            this.deposit = deposit;
            this.numOfMonths = numOfMonths;
            
        }
      
        // Getters and setters
        public double Price { get => price; set => price = value; }
        public double Percentage { get => percentage; set => percentage = value; }
        public double Deposit { get => deposit; set => deposit = value; }
        public double NumOfMonths { get => numOfMonths; set => numOfMonths = value; }
        public double Repayment { get => repayment; set => repayment = value; }

        // Method to calculate home loan monthly repayment
        //Information on how to calculate simple interest taken from the link provided in the PoE https://www.siyavula.com/read/maths/grade-10/finance-and-growth/09-finance-and-growth-03
        
   
        public  double calculate()
        {
            
            double years = numOfMonths / 12;
            double interest = percentage / 100;
            double pAmount = price - deposit;
            
            double total = pAmount * (1 + interest * years);
            repayment = total / numOfMonths;
            return repayment;



        }

        //Alerts user if monthly repayment for the home loan is more than a third of their salary and displays available funds
        public void Alert()
        {
            Helper.netIncome = Helper.income - Helper.totalExpense;
            Helper.netIncome = Math.Round((Double)Helper.netIncome, 2);
            if (Helper.repayment > (0.333 * Helper.income))
            {
                MessageBox.Show("You have to pay R" + Helper.repayment.ToString() + " monthly \nApproval of your home loan is unlikely" + "\n\nAvailable Monthly Money: R" + Helper.netIncome.ToString(), "Home Loan Status", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //information on message boxes taken from https://www.c-sharpcorner.com/UploadFile/736bf5/messagebox-show/
            }
            else
            {

                MessageBox.Show("You have to pay R" + Helper.repayment.ToString() + " monthly \nApproval of your home loan is likely" + "\n\nAvailable Monthly Money: R" + Helper.netIncome.ToString(), "Home Loan Status", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
            //If user inputs number of months out of bounds,they will be alerted
            public void MonthAlert() {
                if (Helper.numOfMonths > 360 || Helper.numOfMonths < 240)
                {
                 MessageBox.Show("Number of months are invalid\nPlease choose a repayment period between 240 and 360 months", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        
        
    }
   


}
