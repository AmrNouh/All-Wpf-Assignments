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

namespace FormUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtFirstName.Text) && String.IsNullOrWhiteSpace(txtLastName.Text) && String.IsNullOrWhiteSpace(txtGender.Text) && String.IsNullOrWhiteSpace(txtAddress.Text) && String.IsNullOrWhiteSpace(txtPhone.Text) && String.IsNullOrWhiteSpace(txtMobile.Text) && String.IsNullOrWhiteSpace(txtEmail.Text) && String.IsNullOrWhiteSpace(txtJobTitle.Text))
            {
                MessageBox.Show( "Please Enter Empty Fields","Error");
            }
            else
            {
                string enteredData = $"FirstName: {txtFirstName.Text}\nLastName: {txtLastName.Text}\nGender: {txtGender.Text}\nAddress: {txtAddress.Text}\nPhone: {txtPhone.Text}\nMobile: {txtMobile.Text}\nEmail: {txtEmail.Text}\nJob Title: {txtJobTitle.Text}";

                if (MessageBox.Show( enteredData, "Data Entered", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    MessageBox.Show("Data Successfully Saved", "Success", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show( "You Cancel Saving Data", "Cancelled", MessageBoxButton.OK);
                }
            }

        }

        private void ClearData(object sender, RoutedEventArgs e)
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtGender.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtMobile.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtJobTitle.Text = String.Empty;
        }

        private void CloseWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Close Window ?", "Exit", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
