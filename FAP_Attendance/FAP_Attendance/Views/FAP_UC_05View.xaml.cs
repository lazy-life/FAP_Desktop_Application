using FAP_Attendance.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FAP_Attendance.Views
{
    /// <summary>
    /// Interaction logic for FAP_UC_05View.xaml
    /// </summary>
    public partial class FAP_UC_05View : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty =
    DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<AttendanceStudent>), typeof(FAP_UC_05View), new PropertyMetadata(null));

        public ObservableCollection<AttendanceStudent> ItemsSource
        {
            get { return (ObservableCollection<AttendanceStudent>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public FAP_UC_05View()
        {
            InitializeComponent();
        }
    }
}
