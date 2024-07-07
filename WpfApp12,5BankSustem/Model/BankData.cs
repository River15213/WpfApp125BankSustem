using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp12_5BankSustem.Model;

namespace WpfApp125BankSustem.Model
{
    internal class BankData<T>
    {
        private static int IdCount = 0;
        public int Id { get; set; }
        public string FullName { get; set; }
        public T NumberAccount {  get; set; }
        public string TypeAccount { get; set; }
        public double BalanceAccount { get; set; }
        public string StatusAccount { get; set; }


        public BankData(string fullName, T numberAccount, string typeAccount, double balanceAccount, string statusAccount)
        {
            Id = ++IdCount;
            FullName = fullName;
            NumberAccount = numberAccount;
            TypeAccount = typeAccount;
            BalanceAccount = balanceAccount;
            StatusAccount = statusAccount;
        }

    }
}
