using FAP_Attendance.Helpers;
using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
using FAP_Attendance.Models;
using PCS_APP;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FAP_Attendance.Views
{
    /// <summary>
    /// Interaction logic for FAP_UC_01View.xaml
    /// </summary>
    public partial class FAP_UC_01View : UserControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(FAP_UC_01View), new PropertyMetadata(null));

        public FAP_UC_01View()
        {
            InitializeComponent();
            DataContext = Manager.Resolve<IFAP_UC_01ViewModel>();
            Name.Text = SessionData._User.Name.ToUpper();
            Username.Text = SessionData._User.UserCode.ToUpper();
        }
        /// <summary>
        ///ImageClose_MouseLeftButtonDown method used to when click image close(x) then  window will be closed 
        /// </summary>
        public void Exit_App(object sender, EventArgs e)
        {
            var confirm = Manager.Resolve<FAP_PU_CONFIRM_EXIT_APP>();
            confirm.Show();
        }
        public void Log_Out(object sender, EventArgs e)
        {
            // Get a reference to the parent window
            Window parentWindow = Window.GetWindow(FAP_UC_01);

            var fap_login = Manager.Resolve<FAP_LOGIN_View>();
            Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
            fap_login.Show();
            // Close the parent window
            parentWindow.Close();
        }
        public void Home_App(object sender, EventArgs e)
        {
            // Get a reference to the parent window
            Window parentWindow = Window.GetWindow(FAP_UC_01);
            var userLogin = SessionData._User;
            if (userLogin.Role == 1)
            {
                var fap_student_home = Manager.Resolve<FAP_STUDENT_HOME_View>();
                Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
                fap_student_home.Show();
            }
            if (userLogin.Role == 2)
            {
                var fap_teacher_home = Manager.Resolve<FAP_TEACHER_HOME_View>();
                Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
                fap_teacher_home.Show();
            }
            if (userLogin.Role == 3)
            {
                var fap_manager_home = Manager.Resolve<FAP_MANAGER_HOME_View>();
                Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
                fap_manager_home.Show();
            }
            // Close the parent window
            parentWindow.Close();
        }




    }
}
