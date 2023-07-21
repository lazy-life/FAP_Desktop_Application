using FAP_Attendance.Helpers;
using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
using FAP_Attendance.Views;
using PCS_APP;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FAP_Attendance.ViewModels
{
    public class FAP_UC_01ViewModel:BindableBase, IFAP_UC_01ViewModel
    {
        #region Fields
        private string _username;
        private string _name;
        #endregion Fields

        #region Properties
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        #endregion Properties
        #region Commands
        public DelegateCommand<Window> LogoutCommand { get; set; }
        #endregion Commands

        #region Contractor
        public FAP_UC_01ViewModel()
        {
            LogoutCommand = new DelegateCommand<Window>(HandleLogoutOnClick);
        }
        #endregion Contractor

        #region Method
        private void HandleLogoutOnClick(Window window)
        {
            LogoutCommon(window);
            Name = SessionData._User.Userfullname.ToUpper();
            Username = SessionData._User.Usernumber.ToUpper();
        }

        private void LogoutCommon(Window window)
        {
            var fap_student_home = Manager.Resolve<FAP_STUDENT_HOME_View>();
            Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
            fap_student_home.ShowDialog();
            window.Close();
        }
        #endregion Method
    }
}
