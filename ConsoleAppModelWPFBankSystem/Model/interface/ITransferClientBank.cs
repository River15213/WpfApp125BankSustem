using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp125BankSustem.Model;

namespace WpfApp12_5BankSustem.Model.@interface
{
    public interface ITransferClientBank<in T>
    {
        void TransferMoneyClient(List<BankData<int>> clientBank, T transferFromId, T transferToNumberTransfer, double sumTransfer);

    }
}
