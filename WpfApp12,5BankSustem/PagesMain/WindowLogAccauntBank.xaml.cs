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
using WpfApp12_5BankSustem.Services;

namespace WpfApp12_5BankSustem.PagesMain
{
    /// <summary>
    /// Логика взаимодействия для WindowLogAccauntBank.xaml
    /// </summary>
    public partial class WindowLogAccauntBank : Window
    {
        private ActionLog actionLog = ActionLog.ListLog;   
        public WindowLogAccauntBank()
        {
            InitializeComponent();
            var infoLog = actionLog.GetList();
            LogInfoDataGrid.ItemsSource = infoLog.ToList();
        }
    }
}
