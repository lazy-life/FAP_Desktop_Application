using FAP_Attendance.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FAP_Attendance.Views
{
    /// <summary>
    /// Interaction logic for FAP_UC_03View.xaml
    /// </summary>
    public partial class FAP_UC_03View : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty =
    DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<Attendance>), typeof(FAP_UC_03View), new PropertyMetadata(null));

        public ObservableCollection<Attendance> ItemsSource
        {
            get { return (ObservableCollection<Attendance>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public FAP_UC_03View()
        {
            InitializeComponent();
        }
    }
}
