using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp12_5BankSustem.Services
{
    public delegate void AlertsAccauntBank(string message);
    internal class AlertsBank
    {
        public event AlertsAccauntBank OnAlertsAccauntBank;
        public void OnAlerts(string message)
        {
            OnAlertsAccauntBank?.Invoke(message);
        }
    }
}
