using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Budget
{
    class Rent:Expense
    //inheritence-Expense class is the base class,Rent is the child class
    {   //variables decalred
        private double leasePeriod;
        
        
        //constructor created
        //I used the MenuApp made in class as a reference on how to make a constructor with parent class included.
        public Rent(double leasePeriod,string name,double amount) : base(name,amount)
        {
            this.leasePeriod = leasePeriod;
        }
        //getter and setter
        public double LeasePeriod { get => leasePeriod; set => leasePeriod = value; }
        //////////////////////////////////////
        public void RentAlert()
        {
            Helper.netIncome = Helper.income - Helper.totalExpense;
            Helper.netIncome = Math.Round((Double)Helper.netIncome, 2);
            //Displays available funds to the user
            MessageBox.Show("Available Monthly Money: R" + Helper.netIncome.ToString()+"\nRent: R"+Helper.rentalAmount+" monthly,with a lease period of "+Helper.leasePeriod+" months", "Balance", MessageBoxButton.OK, MessageBoxImage.Information);

        }
       
    }
}
