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
    public class FAP_TEACHER_HOME_ViewModel: BindableBase, IFAP_TEACHER_HOME_ViewModel
    {
        #region Commands
        public DelegateCommand<Window> TakeAttendanceCommand { get; set; }
        #endregion Commands

        #region Contractor
        public FAP_TEACHER_HOME_ViewModel()
        {
            TakeAttendanceCommand = new DelegateCommand<Window>(HandleTakeAttendanceOnClick);
        }
        #endregion Contractor

        #region Method
        private void HandleTakeAttendanceOnClick(Window window)
        {
            TakeAttendanceCommon(window);
        }

        private void TakeAttendanceCommon(Window window)
        {
            var fap_teacher_attendance = Manager.Resolve<FAP_PU_TEACHER_ATTENDANCE_View>();
            Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
            FAP_PU_TEACHER_ATTENDANCE_ViewModel.Windows = window;
            fap_teacher_attendance.ShowDialog();
        }

        public event EventHandler RequestClose;

        public void CloseWindow()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
        #endregion Method
    }
}
