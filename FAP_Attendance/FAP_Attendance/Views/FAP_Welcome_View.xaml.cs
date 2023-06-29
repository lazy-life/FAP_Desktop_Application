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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FAP_Attendance.Views
{
    /// <summary>
    /// Interaction logic for FAP_Welcome_View.xaml
    /// </summary>
    public partial class FAP_Welcome_View : Window
    {
        public FAP_Welcome_View()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard myStoryboard = (Storyboard)this.Resources["myStoryboard"];
            Storyboard myStoryboard1 = (Storyboard)this.Resources["myStoryboard1"];
            myStoryboard.Begin();
            myStoryboard1.Begin();
            await Task.Delay(3000);
            var showLogin = Manager.Resolve<FAP_LOGIN_View>();
            showLogin.Show();
            Close();
        }
    }
}
