using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
using FAP_Attendance.Models;
using FAP_Attendance.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FAP_Attendance.ViewModels
{
    public class FAP_TEACHER_ATTENDANCE_ViewModel : BindableBase, IFAP_TEACHER_ATTENDANCE_ViewModel
    {
        #region Fields
        private ObservableCollection<AttendanceStudent> _listAttendance;
        #endregion Fields
        #region Properties
        public ObservableCollection<AttendanceStudent> ListAttendance
        {
            get => _listAttendance;
            set
            {
                SetProperty(ref _listAttendance, value);
            }
        }
        #endregion Properties

        #region Commands
        public DelegateCommand<Window> ButtonBackCommand { get; set; }
        public DelegateCommand<Window> SaveAttendanceCommand { get; set; }
        public DelegateCommand<AttendanceStudent> GetSelectedItem { get; set; }
        public DelegateCommand<AttendanceStudent> PresentCommand { get; set; }
        public DelegateCommand<AttendanceStudent> AbsentCommand { get; set; }
        #endregion Commands

        #region Contractor
        public FAP_TEACHER_ATTENDANCE_ViewModel()
        {
            ButtonBackCommand = new DelegateCommand<Window>(HandelButtonBackOnclick);
            SaveAttendanceCommand = new DelegateCommand<Window>(HandelButtonSaveAttendanceCommandOnclick);
            GetSelectedItem = new DelegateCommand<AttendanceStudent>(HandelGetSelectedItemOnclick);
            PresentCommand = new DelegateCommand<AttendanceStudent>(HandelPresentCommandOnclick);
            AbsentCommand = new DelegateCommand<AttendanceStudent>(HandelAbsentCommandOnclick);
            ListAttendance = new ObservableCollection<AttendanceStudent>();
            InitData();
        }

        private void HandelAbsentCommandOnclick(AttendanceStudent student)
        {
            if (student.Status != 2)
            {
                student.Status = 2;
            }
        }

        private void HandelPresentCommandOnclick(AttendanceStudent student)
        {
            if (student.Status != 1)
            {
                student.Status = 1;
            }
        }
        #endregion Contractor

        #region Methods
        private void HandelButtonBackOnclick(Window window)
        {
            ButtonBack(window);
        }
        
        private void HandelButtonSaveAttendanceCommandOnclick(Window window)
        {
            var FAP_TEACHER_HOME = Manager.Resolve<FAP_TEACHER_HOME_View>();
            FAP_TEACHER_HOME.Show();
            window.Close();
        }
        private void HandelGetSelectedItemOnclick(AttendanceStudent selectedItem)
        {

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
            ListAttendance.Add(new AttendanceStudent(1, "SE1629", "HE12345", "Dao Trung Duc", 1, 2));
            ListAttendance.Add(new AttendanceStudent(1, "SE1629", "HE12356", "Tran Ngoc Cuong", 0, 2));
            ListAttendance.Add(new AttendanceStudent(1, "SE1629", "HE12345", "Ly Hong Ngoc", 2, 2));
            ListAttendance.Add(new AttendanceStudent(1, "SE1629", "HE12323", "Nguyen Quang Khai", 2, 2));
            ListAttendance.Add(new AttendanceStudent(1, "SE1629", "HE12476", "Phan Nhat Linh", 1, 2));
            ListAttendance.Add(new AttendanceStudent(1, "SE1629", "HE12336", "Nguyen Tran Ka Long", 0, 2));
            ListAttendance.Add(new AttendanceStudent(1, "SE1629", "HE12379", "Nguyen Do Uyen Nhi", 0, 2));
            ListAttendance.Add(new AttendanceStudent(1, "SE1629", "HE12396", "Tran Ngoc Van Minh Quang", 0, 2));
            ListAttendance.Add(new AttendanceStudent(1, "SE1629", "HE12309", "Nguyen Xuan Hung", 0, 2));
            ListAttendance.Add(new AttendanceStudent(1, "SE1629", "HE12349", "Ngo Minh Tien", 0, 2));
        }



        public event EventHandler RequestClose;

        private void CloseWindow()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
        #endregion Methods
    }
}
