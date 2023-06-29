using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
using FAP_Attendance.ViewModels;
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
    /// Interaction logic for FAP_TEACHER_HOME_View.xaml
    /// </summary>
    public partial class FAP_TEACHER_HOME_View : Window
    {
        public FAP_TEACHER_HOME_View()
        {
            InitializeComponent();
            DataContext = Manager.Resolve<IFAP_TEACHER_HOME_ViewModel>();
            (DataContext as FAP_TEACHER_HOME_ViewModel).RequestClose += (s, e) => this.Close();
        }
    }
}
