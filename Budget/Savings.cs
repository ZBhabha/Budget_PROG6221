using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Budget
{
    class Savings
    {
        private string save;

        public Savings(string save)
        {
            this.save = save;
        }

        public string Save { get => save; set => save = value; }
        //method to calculate monthly saving amount to reach goal
        //Based on first year payment as interest is compunded annually so amount might vary yearly
        //Compund interest formula and present value formula used when creating the method
        public  double calcSaving()
        {

            double interest = Helper.interestRate / 100;
            //Math.Pow() learnt from :
            //Author: jit_t
            //Link: https://www.geeksforgeeks.org/c-sharp-math-pow-method/
            double pAmount = Helper.amount / Math.Pow((1 + interest), Helper.year);
            double months = Helper.year * 12;

            double monthlySave = pAmount / months;
            MessageBox.Show("Monthly saving for " + save +" is R" + Math.Round((Double)monthlySave, 2)  + " to reach R" + Helper.amount + " in " + Helper.year + " years.", "Savings", MessageBoxButton.OK, MessageBoxImage.Information);

            return monthlySave;


        }

    }
}
