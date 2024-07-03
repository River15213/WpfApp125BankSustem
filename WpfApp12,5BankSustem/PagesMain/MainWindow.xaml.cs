using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp12_5BankSustem.PagesMain;
using WpfApp125BankSustem.Model;
using WpfApp125BankSustem.Services;

namespace WpfApp125BankSustem.PagesMain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StandartClientBankWPF<int> clietnBank = new StandartClientBankWPF<int>();
        private List<BankData<int>> client;

        public MainWindow()
        {
            InitializeComponent();
            client = clietnBank.bankClientBase();
            dataGridBankData.ItemsSource = client;
        }

        private void CloseAccountButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = dataGridBankData.SelectedItem as BankData<int>;
            if (selectedUser != null)
            {
                var idClient = selectedUser.Id;
                clietnBank.DeleteClient(client, idClient);
                dataGridBankData.Items.Refresh();
                MessageBox.Show("Клиент удален.");
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления.");
            }
        }

        private void ButtonOpenAcc_Click(object sender, RoutedEventArgs e)
        {
            WindowAddClient windowAddClient = new WindowAddClient();
            if (windowAddClient.ShowDialog() == true)
            {
                clietnBank.AddClientBank(client, windowAddClient.fullName, windowAddClient.typeAccount, "Обычный");
                dataGridBankData.ItemsSource = client;
                dataGridBankData.Items.Refresh();
            }
        }

        private void TransferMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            var transferClient = dataGridBankData.SelectedItem as BankData<int>;
            if (transferClient != null)
            {
                var idClientFromTransfer = transferClient.Id;

                WindowTransferClients windowTransferClients = new WindowTransferClients();
                if (windowTransferClients.ShowDialog() == true)
                {
                    clietnBank.TransferMoneyClient(client, idClientFromTransfer, windowTransferClients.numberAccTransfer, windowTransferClients.sumTransfer);
                    dataGridBankData.ItemsSource = client;
                    dataGridBankData.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберете клиента для перевода.");
            }

        }
    }
}