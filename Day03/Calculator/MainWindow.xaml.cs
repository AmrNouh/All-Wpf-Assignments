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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sign = null;
        double operand1;
        double operand2;
        bool flag = true;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content)
            {
                case "×":
                case "+":
                case "-":
                case "÷":
                    if (flag)
                    {
                        sign = (string)((Button)sender).Content;
                        if (sign == "-")
                        {
                            if (txtNumber.Text.Length > 0)
                            {
                                txtFormula.Text = $"{txtNumber.Text} {((Button)sender).Content} ";
                                double.TryParse(txtNumber.Text, out operand1);
                                txtNumber.Clear();
                            }
                            else
                            {
                                txtNumber.Text = "- ";
                            }
                        }
                        else
                        {
                            txtFormula.Text = $"{txtNumber.Text} {((Button)sender).Content} ";
                            double.TryParse(txtNumber.Text, out operand1);
                            txtNumber.Clear();
                        }
                        flag = false;
                    }

                    break;
                case "=":
                    if (!flag)
                    {
                        double.TryParse(txtNumber.Text, out operand2);
                        txtFormula.AppendText($"{txtNumber.Text} =");
                        flag = true;
                        switch (sign)
                        {
                            case "+":
                                txtNumber.Text = $"{operand1 + operand2}";
                                break;
                            case "×":
                                txtNumber.Text = $"{operand1 * operand2}";
                                break;
                            case "-":
                                txtNumber.Text = $"{operand1 - operand2}";
                                break;
                            case "÷":
                                if (operand2 > 0)
                                {
                                    txtNumber.Text = $"{operand1 / operand2}";
                                }
                                else
                                {
                                    MessageBox.Show("Divide by Zero", "Invalid Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        private void Operand_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    txtNumber.AppendText((string)((Button)sender).Content);
                    break;
                case ".":
                    if (txtNumber.Text.Length > 0)
                    {
                        txtNumber.AppendText((string)((Button)sender).Content);
                    }
                    else
                    {
                        txtNumber.AppendText($"0{((Button)sender).Content}");
                    }
                    break;
            }
        }
    }
}
