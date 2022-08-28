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
using System.Windows.Shapes;

namespace Budget
{//Background form picture taken from:
    //Author: belchonock
    //Link: https://st2.depositphotos.com/1177973/7977/i/600/depositphotos_79779102-stock-photo-toy-car-money-documents.jpg
    /// <summary>
    /// Interaction logic for WinVehicle.xaml
    /// </summary>
    public partial class WinVehicle : Window
    {
        public WinVehicle()
        {
            InitializeComponent();
            listBox1.Visibility = Visibility.Hidden;
            lblExpense.Visibility = Visibility.Hidden;
            btnExpense.Visibility = Visibility.Hidden;
            lblSave.Visibility = Visibility.Hidden;
            rdbSave.Visibility = Visibility.Hidden;
            rdbExit.Visibility = Visibility.Hidden;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string modelMake = txbModel.Text;
                double purchPrice = double.Parse(txbPrice.Text);
                double deposit = double.Parse(txbDeposit.Text);
                double interest = double.Parse(txbInterest.Text);
                double insurance = double.Parse(txbInsurance.Text);
                Helper.loanRepayment = 0;
                string name = modelMake;
                //object created in order to call the calc method to work out loan repayment
                Vehicle v1 = new Vehicle(modelMake, purchPrice, deposit, interest, insurance, name, Helper.loanRepayment);
                v1.calc();
                Helper.loanRepayment = v1.LoanRepayment;
                Helper.loanRepayment = Math.Round((Double)Helper.loanRepayment, 2);
                Vehicle v = new Vehicle(modelMake, purchPrice, deposit, interest, insurance, name, Helper.loanRepayment);
                //loan repayment is nw an expense and is added to the list
                ListUtil.expList.Add(v);
                //monthly loan repayment amount is outputted to  the user as well as available balance
                v.vehicleAlert();

                btnExpense.Visibility = Visibility.Visible;

                //try..catch added to handle exception if user adds spaces or letters such as 'R'
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please do not leave spaces when entering values and only insert numeric values", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExpense_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            
            //notify the user when the total expenses, including loan repayments, exceed 75% of their income
            DelegateUtil d = new DelegateUtil();
            d.NotifyUser();
            listBox1.Visibility = Visibility.Visible;
            lblExpense.Visibility = Visibility.Visible;
            Helper.Descend();
            //code to load list box with expenses in desceding order using Linq
            foreach (Expense item in ListUtil.expList.OrderByDescending(a => a.Amount))
            {
                listBox1.Items.Add(item.ToString());
            }
            lblSave.Visibility = Visibility.Visible;
            rdbSave.Visibility = Visibility.Visible;
            rdbExit.Visibility = Visibility.Visible;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void rdbYes_Checked(object sender, RoutedEventArgs e)
        {
            
            //code to hide and close vehicle window and open savings window
            this.Hide();
            Saving win3 = new Saving();
            win3.ShowDialog();
            this.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you for using our Budget App", "Exit", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
