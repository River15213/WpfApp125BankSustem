using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp12_5BankSustem.Model
{
    public class LogData
    {
        public DateTime DateTime { get; set; }
        public string textLog { get; set; }

        public LogData(string textLog)
        {
            DateTime = DateTime.Now;
            this.textLog = textLog;
        }

        public override string ToString()
        {
            return $"Время: {DateTime}\n Изменено: {textLog}";

        }
    }
}
