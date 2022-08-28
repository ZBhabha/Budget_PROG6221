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
{
    /// <summary>
    /// Interaction logic for Saving.xaml
    /// </summary>
    public partial class Saving : Window
    {
        public Saving()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string save = txbSave.Text;
                //Object created
                Savings s = new Savings(save);
                //variables declared
                Helper.amount = double.Parse(txbAmount.Text);
                Helper.interestRate = double.Parse(txbInterest.Text);
                Helper.year = double.Parse(txbYear.Text);
                //method to calculate montly saving called
                s.calcSaving();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please do not leave spaces when entering values and only insert numeric values(unless stated otherwise)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
