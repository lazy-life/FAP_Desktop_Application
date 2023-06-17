using FAP_Attendance.Helpers;
using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
using FAP_Attendance.Managers.Model;
using FAP_Attendance.Views;
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
    public class FAP_LOGIN_ViewModel : BindableBase, IFAP_LOGIN_ViewModel
    {
        #region Commands
        public DelegateCommand<Window> LoginCommand { get; set; }
        #endregion Commands

        #region Contractor
        public FAP_LOGIN_ViewModel()
        {
            LoginCommand = new DelegateCommand<Window>(HandleLoginOnClick);
        }
        #endregion Contractor

        #region Method
        private void HandleLoginOnClick(Window window)
        {
            LoginCommon(window);
        }

        private void LoginCommon(Window window)
        {
            var fap_student_home = Manager.Resolve<FAP_STUDENT_HOME_View>();
            Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
            fap_student_home.Show();
            window.Close();
        }
        #endregion Method
    }
}
