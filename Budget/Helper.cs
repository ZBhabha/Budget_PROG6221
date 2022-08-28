using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Budget
{ 
class Helper
    {  //global variables to allow access across the whole app
        public static double income;
        public static double repayment;
        public static double netIncome;
        public static double numOfMonths;
        public static double rentalAmount;
        public static double leasePeriod;
        public static double loanRepayment;
        public static double totalExpense;
        public static double amount;
       
        public static double interestRate;
        public static double year;

        // method to notify the user when the total expenses, including loan repayments, exceed 75% of their income
        public void Warning()
        {
            //code to find the sum of all expenses adapted from Stackoverflow:
            //Author:usefulBee
            //Link: https://stackoverflow.com/a/36165855
            double sum = ListUtil.expList.Sum(i => i.Amount);
         
        if ((income*0.75) < sum )
            {
                MessageBox.Show("Warning: Your expenses are high\nExpenses exceed 75% of your income","Expenses Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        
        // method containing code for OrderByDescending Linq
        //Linq learned and adapted from youtube video
        //Author VCSOIT
        //Link:https://youtu.be/15C9afmLD4Y
        public static void Descend()
        {
            var OrderByDescending = from a in ListUtil.expList
                                    orderby a.Amount descending
                                    select a;
            return;
        }

       

    }
}
