using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp12_5BankSustem.Model.@interface;

namespace WpfApp12_5BankSustem.Model
{
    public class DepositAccount : ITypeAccount<string> 
    {
        public string TypeAccount => "Депозитный";
    }
}
