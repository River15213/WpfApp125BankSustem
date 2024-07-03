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

namespace WpfApp12_5BankSustem.PagesMain
{
    /// <summary>
    /// Логика взаимодействия для WindowTransferClients.xaml
    /// </summary>
    public partial class WindowTransferClients : Window
    {
        public int numberAccTransfer {  get; set; }
        public double sumTransfer { get; set; }
        public WindowTransferClients()
        {
            InitializeComponent();
            SumTransferLabel.Visibility = Visibility.Hidden;
            InputSumTransferTextBox.Visibility = Visibility.Hidden;
            SendTransferButton.Visibility = Visibility.Hidden;
        }

        private void CheckAccButton_Click(object sender, RoutedEventArgs e)
        {
            var inputUser = TextBoxTransfer.Text;
            if (inputUser != null)
            {
                if(int.TryParse(inputUser, out int numberInputTransfer))
                {
                    SumTransferLabel.Visibility = Visibility.Visible;
                    InputSumTransferTextBox.Visibility = Visibility.Visible;
                    SendTransferButton.Visibility = Visibility.Visible;
                    numberAccTransfer = numberInputTransfer;
                }
                else
                {
                    MessageBox.Show("Введите цифры.");
                }
            }
            else
            {
                MessageBox.Show("Введите номер счета.");
            }
        }

        private void SendTransferButton_Click(object sender, RoutedEventArgs e)
        {
            var inputUser = InputSumTransferTextBox.Text;
            if (inputUser != null)
            {
                if(double.TryParse(inputUser, out double inputSumTransfer))
                {
                    sumTransfer = inputSumTransfer;
                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Введите сумму.");
                }
            }
            else
            {
                MessageBox.Show("Введите сумму перевода");
            }
        }
    }
}
