using FAP_Attendance.Helpers;
using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
using FAP_Attendance.Models;
using FAP_Attendance.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace FAP_Attendance.ViewModels
{
    public class FAP_PU_TEACHER_ATTENDANCE_ViewModel:BindableBase, IFAP_PU_TEACHER_ATTENDANCE_ViewModel
    {
        #region Fields
        private ObservableCollection<TeacherTakeClass> _listClassTakeAttendance;
        private TeacherTakeClass _selectedTeacher;
        public static Window Windows;
        #endregion Fields
        #region Properties
        public ObservableCollection<TeacherTakeClass> ListClassTakeAttendance
        {
            get => _listClassTakeAttendance;
            set
            {
                SetProperty(ref _listClassTakeAttendance, value);
            }
        }

        public TeacherTakeClass SelectedTeacher
        {
            get => _selectedTeacher;
            set => SetProperty(ref _selectedTeacher, value);
        }
        #endregion Properties

        #region Commands
        public DelegateCommand<Window> ButtonBackCommand { get; set; }
        public DelegateCommand<TeacherTakeClass> GetSelectedItem { get; set; }
        #endregion Commands

        #region Contractor
        public FAP_PU_TEACHER_ATTENDANCE_ViewModel()
        {
            ButtonBackCommand = new DelegateCommand<Window>(HandelButtonBackOnclick);
            GetSelectedItem = new DelegateCommand<TeacherTakeClass>(HandelGetSelectedItemOnclick);
            ListClassTakeAttendance = new ObservableCollection<TeacherTakeClass>();
            InitData();
        }
        #endregion Contractor

        #region Methods
        private void HandelButtonBackOnclick(Window window)
        {
            ButtonBack(window);
        }
         private void HandelGetSelectedItemOnclick(TeacherTakeClass selectedItem)
        {
            // Find the item with the specified ID
            SelectedTeacher = selectedItem;
            //save model to sesstion and get it when move next window
            var takeAttendance = Manager.Resolve<FAP_TEACHER_ATTENDANCE_View>();
            takeAttendance.Show();
            CloseWindow();
            Windows.Close();
        }

        private void ButtonBack(Window window)
        {
            window.Close();
        }

        private void OpenTakeAttendance()
        {
            var attendace = Manager.Resolve<FAP_TEACHER_ATTENDANCE_View>();
            attendace.Show();
        }

        private void InitData()
        {
            ListClassTakeAttendance.Add(new TeacherTakeClass(1, DateTime.Now, DateTime.Now, "PRU221m", "SE1612", "DE-203"));
            ListClassTakeAttendance.Add(new TeacherTakeClass(2, DateTime.Now, DateTime.Now, "PRM321", "SE1614", "DE-203"));
            ListClassTakeAttendance.Add(new TeacherTakeClass(3, DateTime.Now, DateTime.Now, "PRF192", "SE1619", "DE-203"));
        }

        public event EventHandler RequestClose;

        private void CloseWindow()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
        #endregion Methods
    }
}
