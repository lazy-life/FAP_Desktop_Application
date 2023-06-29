using FAP_Attendance.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FAP_Attendance.Views
{
    /// <summary>
    /// Interaction logic for FAP_UC_02View.xaml
    /// </summary>
    public partial class FAP_UC_02View : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty =
    DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<WeeklyTimetable>), typeof(FAP_UC_02View), new PropertyMetadata(null));

        public ObservableCollection<TimeTable> ItemsSource
        {
            get { return (ObservableCollection<TimeTable>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public FAP_UC_02View()
        {
            InitializeComponent();
        }
    }
}
