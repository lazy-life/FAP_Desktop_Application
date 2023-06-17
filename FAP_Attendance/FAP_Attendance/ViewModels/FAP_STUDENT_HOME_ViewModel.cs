using FAP_Attendance.Helpers;
using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
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
    public class FAP_STUDENT_HOME_ViewModel : BindableBase, IFAP_STUDENT_HOME_ViewModel
    {
        #region Commands
        public DelegateCommand<Window> AttendanceReportCommand { get; set; }
        #endregion Commands

        #region Contractor
        public FAP_STUDENT_HOME_ViewModel()
        {
            AttendanceReportCommand = new DelegateCommand<Window>(HandelAttendanceReportOnclick);
        }
        #endregion Contractor

        #region Methods
        private void HandelAttendanceReportOnclick(Window window)
        {
            AttendanceReport(window);
        }

        private void AttendanceReport(Window window)
        {
            var fap_student_attendance = Manager.Resolve<FAP_STUDENT_ATTENDANCE_View>();
            Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
            fap_student_attendance.Show();
            window.Close();
        }
        #endregion Methods
    }
}
