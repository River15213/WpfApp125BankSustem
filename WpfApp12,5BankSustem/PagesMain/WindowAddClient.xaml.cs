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

namespace WpfApp125BankSustem.PagesMain
{
    /// <summary>
    /// Логика взаимодействия для WindowAddClient.xaml
    /// </summary>
    public partial class WindowAddClient : Window
    {
        public string fullName {  get; set; }
        public string typeAccount { get; set; }
        public WindowAddClient()
        {
            InitializeComponent();
            LabelChoiceType.Visibility = Visibility.Hidden;
            ComboBoxTypeAcc.Visibility = Visibility.Hidden;
            AddClientBankButton.Visibility = Visibility.Hidden;
            ComboBoxTypeAcc.Items.Add("Депозитный");
            ComboBoxTypeAcc.Items.Add("Недепозитный");

        }

        private void AddClientBankButton_Click(object sender, RoutedEventArgs e)
        {
            if(ComboBoxTypeAcc.SelectedItem != null) 
            {
                typeAccount = ComboBoxTypeAcc.Text;
                MessageBox.Show("Клиент сохранен.");
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите тип счета.");
            }
        }

        private void SaveFullNameButton_Click(object sender, RoutedEventArgs e)
        {
            var fullnameClient = TextBoxFullName.Text;
            
            if(fullnameClient != null)
            {
                var splitFullname = fullnameClient.Split(" ");
                if (splitFullname.Length == 3)
                {
                    fullName = fullnameClient;
                    LabelChoiceType.Visibility = Visibility.Visible;
                    ComboBoxTypeAcc.Visibility = Visibility.Visible;
                    AddClientBankButton.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Неверное имя");
                }

            }
            else
            {
                MessageBox.Show("Введите имя");
            }

        }
    }
}
