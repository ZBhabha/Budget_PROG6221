using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Budget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblRent.Visibility = Visibility.Hidden;
            txbRent.Visibility = Visibility.Hidden;
            lblLoan.Visibility = Visibility.Hidden;
            lblPrice.Visibility = Visibility.Hidden;
            txbPrice.Visibility = Visibility.Hidden;
            lblInterest.Visibility = Visibility.Hidden;
            txbInterest.Visibility = Visibility.Hidden;
            lblDeposit.Visibility = Visibility.Hidden;
            txbDeposit.Visibility = Visibility.Hidden;
            lblMonths.Visibility = Visibility.Hidden;
            txbMonths.Visibility = Visibility.Hidden;
            lblLease.Visibility = Visibility.Hidden;
            txbLease.Visibility = Visibility.Hidden;
            btnExpense.Visibility = Visibility.Hidden;
            lstbxExp.Visibility = Visibility.Hidden;
            lblExp.Visibility = Visibility.Hidden;
            lblSave.Visibility = Visibility.Hidden;
            rdbSave.Visibility = Visibility.Hidden;
            rdbExit.Visibility = Visibility.Hidden;
            lbl.Visibility = Visibility.Hidden;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // income variable 
                Helper.income = double.Parse(txbIncome.Text);

                // Tax 
                string tax = "Tax Deduction";
                double taxDeduction = double.Parse(txbTax.Text);
                GeneralExpense g = new GeneralExpense(tax, taxDeduction);
                //Tax is now added to the list
                ListUtil.expList.Add(g);

                // Grocery
                string grocery = "Grocery Costs";
                double groceryCosts = double.Parse(txbGroceries.Text);
                GeneralExpense g1 = new GeneralExpense(grocery, groceryCosts);
                //Grocery is now added to the list
                ListUtil.expList.Add(g1);

                //Utility
                string utility = "Utility Costs";
                double utilityCosts = double.Parse(txbWaterLights.Text);
                GeneralExpense g2 = new GeneralExpense(utility, utilityCosts);
                //Utility is now added to the list
                ListUtil.expList.Add(g2);

                //Travel
                string travel = "Travel Costs";
                double travelCosts = double.Parse(txbTravel.Text);
                GeneralExpense g3 = new GeneralExpense(travel, travelCosts);
                //Travel is now added to the list
                ListUtil.expList.Add(g3);

                //Phone
                string phone = "Cellphone & Telephone Costs";
                double phoneCosts = double.Parse(txbPhone.Text);
                GeneralExpense g4 = new GeneralExpense(phone, phoneCosts);
                //Phone is now added to the list
                ListUtil.expList.Add(g4);

                //Other
                string other = "Other Costs";
                double otherCosts = double.Parse(txbExpenses.Text);
                GeneralExpense g5 = new GeneralExpense(other, otherCosts);
                //Otheris now added to the list
                ListUtil.expList.Add(g5);









                // If the user chooses to buy property this block of code will run and the calculations will be done according to buying costs
                if (rdbBuy.IsChecked == true)
                {
                    //variables declared
                    double price = double.Parse(txbPrice.Text);
                    double percentage = double.Parse(txbInterest.Text);
                    double deposit = double.Parse(txbDeposit.Text);
                    Helper.numOfMonths = double.Parse(txbMonths.Text);
                    Helper.repayment = 0;
                    string loanName = "Home Loan Repayment";
                    //object created in order to call calculate method
                    HomeLoan h1 = new HomeLoan(price, percentage, deposit, Helper.numOfMonths, loanName, Helper.repayment);

                    h1.MonthAlert();
                    //method call in order to work out repayment
                    h1.calculate();
                    Helper.repayment = h1.Repayment;
                    //code attribution
                    //Rounding off a double value to 2 decimal places adapted from Stackoverflow
                    //Author:Tim Cooper
                    //Link:https://stackoverflow.com/a/2357866
                    Helper.repayment = Math.Round((Double)Helper.repayment, 2);
                    //new object created for actual use now that repayment is worked out
                    HomeLoan h = new HomeLoan(price, percentage, deposit, Helper.numOfMonths, loanName, Helper.repayment);


                    // the home loan repayment is now an expense and is added to the list
                    ListUtil.expList.Add(h);
                    //Calculations to work out income after deductions
                    Helper.totalExpense = taxDeduction + groceryCosts + phoneCosts + otherCosts + utilityCosts + travelCosts + Helper.repayment;
                    //Method to tell the user how much money is left after expenses
                    h.Alert();


                    // If the user chooses to rent this block of code will run and the calculations will be done according to rental costs
                }
                else if (rdbRent.IsChecked == true)
                {
                    Helper.rentalAmount = double.Parse(txbRent.Text);
                    Helper.leasePeriod = double.Parse(txbLease.Text);
                    string rentName = "Rental Cost";

                    //object created
                    Rent r = new Rent(Helper.leasePeriod, rentName, Helper.rentalAmount);

                    // rental is now an expense and is added to the array
                    ListUtil.expList.Add(r);
                    //calculations to work out income after deductions
                    Helper.totalExpense = taxDeduction + groceryCosts + utilityCosts + phoneCosts + travelCosts + otherCosts + Helper.rentalAmount;
                    //Method to tell the user how much money is left after expenses
                    r.RentAlert();


                }
                //try..catch added to handle exception if user adds spaces or letters such as 'R'
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please do not leave spaces when entering values and only insert numeric values", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnExpense_Click(object sender, RoutedEventArgs e)
        {
            lstbxExp.Items.Clear();
            //notify the user when the total expenses, including loan repayments, exceed 75% of their income
            DelegateUtil d = new DelegateUtil();
            d.NotifyUser();
            lstbxExp.Visibility = Visibility.Visible;

            lblExp.Visibility = Visibility.Visible;
            Helper.Descend();
            // loop to add all expenses to the listbox in descending order using Linq
            foreach (Expense item in ListUtil.expList.OrderByDescending(a => a.Amount))
            {
                lstbxExp.Items.Add(item.ToString());
            }
            lblSave.Visibility = Visibility.Visible;
            rdbSave.Visibility = Visibility.Visible;
            rdbExit.Visibility = Visibility.Visible;
            lbl.Visibility = Visibility.Visible;
        }

        private void rdbRent_Checked(object sender, RoutedEventArgs e)
        {     
                lblRent.Visibility = Visibility.Visible;
                txbRent.Visibility = Visibility.Visible;
                lblLease.Visibility = Visibility.Visible;
                txbLease.Visibility = Visibility.Visible;
            lblLoan.Visibility = Visibility.Hidden;
            lblPrice.Visibility = Visibility.Hidden;
            txbPrice.Visibility = Visibility.Hidden;
            lblInterest.Visibility = Visibility.Hidden;
            txbInterest.Visibility = Visibility.Hidden;
            lblDeposit.Visibility = Visibility.Hidden;
            txbDeposit.Visibility = Visibility.Hidden;
            lblMonths.Visibility = Visibility.Hidden;
            txbMonths.Visibility = Visibility.Hidden;
        }


        private void rdbBuy_Checked(object sender, RoutedEventArgs e)
        {
            lblRent.Visibility = Visibility.Hidden;
            txbRent.Visibility = Visibility.Hidden;
            lblLease.Visibility = Visibility.Hidden;
            txbLease.Visibility = Visibility.Hidden;
            lblLoan.Visibility = Visibility.Visible;
            lblPrice.Visibility = Visibility.Visible;
            txbPrice.Visibility = Visibility.Visible;
            lblInterest.Visibility = Visibility.Visible;
            txbInterest.Visibility = Visibility.Visible;
            lblDeposit.Visibility = Visibility.Visible;
            txbDeposit.Visibility = Visibility.Visible;
            lblMonths.Visibility = Visibility.Visible;
            txbMonths.Visibility = Visibility.Visible;

        }

        private void txbMonths_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rdbYes_Checked(object sender, RoutedEventArgs e)
        {
            //code to hide and close this window and open vehicle window
            this.Hide();
            WinVehicle win2 = new WinVehicle();
            win2.ShowDialog();
            this.Close();
        }

        private void rdbNo_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbNo.IsChecked==true)
            {
                btnExpense.Visibility = Visibility.Visible;

            }
            else
            {
                btnExpense.Visibility = Visibility.Hidden;
            }
        }

        private void rdbSave_Checked(object sender, RoutedEventArgs e)
        {
            //code to hide and close this window and open savings window
            this.Hide();
            Saving win3 = new Saving();
            win3.ShowDialog();
            this.Close();
        }

        private void rdbExit_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you for using our Budget App", "Exit", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}

