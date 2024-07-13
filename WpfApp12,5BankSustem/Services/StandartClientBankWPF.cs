using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp12_5BankSustem.Model;
using WpfApp12_5BankSustem.Model.@interface;
using WpfApp12_5BankSustem.Services;
using WpfApp125BankSustem.Model;

namespace WpfApp125BankSustem.Services
{
    internal class StandartClientBankWPF<T> : ITransferClientBank<T>
    {
        private ActionLog actionLog;
        private AlertsBank alertsBank;

        public StandartClientBankWPF()
        {
            actionLog = ActionLog.ListLog;
            alertsBank = new AlertsBank();

            alertsBank.OnAlertsAccauntBank += x => actionLog.AddLog(x);
        }

        public List<BankData<T>> bankClientBase()
        {
            List<BankData<T>> bankClients = new List<BankData<T>>();
            ITypeAccount<string> noDepositType = new NoDepositAccount();
            ITypeAccount<string> depositType = new DepositAccount();
            BankData<T> clientOne = new BankData<T>("Иванов Иван Иванович", (T)Convert.ChangeType(54587866, typeof(T)), noDepositType.TypeAccount, 50000, "Обычный");
            BankData<T> clientTwo = new BankData<T>("Иванов Иван Иванович", (T)Convert.ChangeType(342232, typeof(T)), depositType.TypeAccount, 500000, "Обычный");
            BankData<T> clientThree = new BankData<T>("Петров Петр Петрович", (T)Convert.ChangeType(5466776, typeof(T)), depositType.TypeAccount, 10000, "Обычный");
            bankClients.Add(clientOne);
            bankClients.Add(clientTwo);
            bankClients.Add(clientThree);
            alertsBank.OnAlerts($"Клиенты сохранены");
            return bankClients;

        }

        public void DeleteClient(List<BankData<T>> client, int id)
        {
            var findClient = client.FirstOrDefault(x => x.Id == id);
            if (findClient != null)
            {
                client.Remove(findClient);
                alertsBank.OnAlerts($"Клиент {id} удален.");
            }
            
        }

        public void AddClientBank(List<BankData<T>> clientBank, string fullname, string typeAccountStr, string statusAcc)
        {
            ITypeAccount<string> typeAcc = typeAccountStr == "Депозитный" 
                ? new DepositAccount() : new NoDepositAccount();

            var findClient = clientBank.FirstOrDefault(x => x.FullName == fullname && x.TypeAccount == typeAcc.TypeAccount);
            if (findClient == null)
            {

                Random random = new Random();
                int numberAcc = random.Next(10000, 1000000);
                double balanceAss = random.NextDouble() * 1000000;
                BankData<T> client = new BankData<T>(fullname, (T)Convert.ChangeType(numberAcc, typeof(T)), typeAcc.TypeAccount, balanceAss, statusAcc);
                clientBank.Add(client);
                alertsBank.OnAlerts($"Клиент {client.FullName} с типом счета {client.TypeAccount} сохранен.");

            }
            else
            {
                MessageBox.Show("Такой клиент уже есть.");
            }

        }

        public void TransferMoneyClient(List<BankData<int>> clientBank, T transferFromId, T transferToNumberTransfer, double sumTransfer)
        {
            var transferFromClient = clientBank.FirstOrDefault(x => x.Id.Equals(transferFromId));
            var transferToClient = clientBank.FirstOrDefault(x => x.NumberAccount.Equals(transferToNumberTransfer));

            if (transferToClient != null)
            {
                if(transferFromClient.BalanceAccount > sumTransfer)
                {
                    transferFromClient.BalanceAccount -= sumTransfer;
                    transferToClient.BalanceAccount += sumTransfer;
                    alertsBank.OnAlerts($"Сумма {sumTransfer}, переведена c {transferFromClient.FullName} на {transferToClient.FullName}");

                }
                else
                {
                    MessageBox.Show($"Перевод непрошел, у клиента {transferFromClient.FullName} нет {sumTransfer}р");
                }
            }
            else
            {
                MessageBox.Show("Перевод недоступен, такого клиента нет.");
            }
        }

    }
}
