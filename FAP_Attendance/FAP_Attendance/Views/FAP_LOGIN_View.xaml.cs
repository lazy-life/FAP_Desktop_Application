using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
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

namespace FAP_Attendance.Views
{
    /// <summary>
    /// Interaction logic for FAP_LOGIN_View.xaml
    /// </summary>
    public partial class FAP_LOGIN_View : Window
    {
        public FAP_LOGIN_View()
        {
            InitializeComponent();
            DataContext = Manager.Resolve<IFAP_LOGIN_ViewModel>();
        }
    }
}
