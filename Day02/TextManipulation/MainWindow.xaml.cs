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

namespace TextManipulation
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

        private void WritableChanged(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content)
            {
                case "Editable":
                    txtArea.IsReadOnly = false;
                    break;
                case "Read Only":
                    txtArea.IsReadOnly= true;
                    break;
            }
        }

        private void AlignmentChanged(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content)
            {
                case "Left":
                    txtArea.HorizontalContentAlignment = HorizontalAlignment.Left;
                    break;
                case "Center":
                    txtArea.HorizontalContentAlignment = HorizontalAlignment.Center;
                    break;
                case "Right":
                    txtArea.HorizontalContentAlignment = HorizontalAlignment.Right;
                    break;
            }
        }

        private void btnSetText_Click(object sender, RoutedEventArgs e)
        {
            txtArea.Text = "Replace default text with initial text value";
        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            txtArea.Focus();
            txtArea.SelectAll();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtArea.Clear();
        }

        private void btnPrepend_Click(object sender, RoutedEventArgs e)
        {
            txtArea.Focus();
            txtArea.Text = txtArea.Text.Insert(0, " *** Prepended text *** ");
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            txtArea.Focus();
            txtArea.Text = txtArea.Text.Insert(txtArea.CaretIndex, " *** inserted text *** ");
        }

        private void btnAppend_Click(object sender, RoutedEventArgs e)
        {
            txtArea.AppendText(" *** appended text *** ");
        }

        private void btnCut_Click(object sender, RoutedEventArgs e)
        {
            if(txtArea.SelectedText.Length > 0)
                txtArea.Cut();
        }

        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            txtArea.Paste();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            if (txtArea.SelectedText.Length > 0)
                txtArea.Copy();
        }
    }
}
