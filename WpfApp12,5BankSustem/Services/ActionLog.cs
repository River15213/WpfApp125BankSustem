using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp12_5BankSustem.Model;

namespace WpfApp12_5BankSustem.Services
{
    public class ActionLog
    {
        private List<LogData> logData;
        private static ActionLog actionLog;

        public ActionLog() 
        {
            logData = new List<LogData>();
        }
        public static ActionLog ListLog => actionLog ??= new ActionLog();

        public void AddLog(string data)
        {
            logData.Add(new LogData(data));
        }

        public List<LogData> GetList()
        {
            return logData;
        }

    }
}
