using FAP_Attendance.Helpers;
using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
using FAP_Attendance.Models;
using FAP_Attendance.Views;
using PCS_APP;
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
    public class FAP_MANAGER_HOME_ViewModel : BindableBase, IFAP_MANAGER_HOME_ViewModel
    {
        #region Fields
        private ObservableCollection<AttendanceStudent> _listAttendance;
        private string _rollnumber;
        private string _room;
        private int _slot;
        private DateTime _date;
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

        public string Rollnumber
        {
            get => _rollnumber;
            set => SetProperty(ref _rollnumber, value);
        }

        public string Room
        {
            get => _room;
            set => SetProperty(ref _room, value);
        }

        public int Slot
        {
            get => _slot;
            set => SetProperty(ref _slot, value);
        }

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }
        #endregion Properties

        #region Commands
        public DelegateCommand<Window> ButtonBackCommand { get; set; }
        public DelegateCommand<Window> SearchStudentCommand { get; set; }
        public DelegateCommand<Window> SaveAttendanceCommand { get; set; }
        public DelegateCommand<Window> ViewClassCommand { get; set; }
        public DelegateCommand<AttendanceStudent> GetSelectedItem { get; set; }
        public DelegateCommand<AttendanceStudent> PresentCommand { get; set; }
        public DelegateCommand<AttendanceStudent> AbsentCommand { get; set; }
        #endregion Commands

        #region Contractor
        public FAP_MANAGER_HOME_ViewModel()
        {
            ButtonBackCommand = new DelegateCommand<Window>(HandelButtonBackOnclick);
            SearchStudentCommand = new DelegateCommand<Window>(HandelSearchStudentCommandOnclick);
            SaveAttendanceCommand = new DelegateCommand<Window>(HandelButtonSaveAttendanceCommandOnclick);
            ViewClassCommand = new DelegateCommand<Window>(HandelViewClassCommandCommandOnclick);
            GetSelectedItem = new DelegateCommand<AttendanceStudent>(HandelGetSelectedItemOnclick);
            PresentCommand = new DelegateCommand<AttendanceStudent>(HandelPresentCommandOnclick);
            AbsentCommand = new DelegateCommand<AttendanceStudent>(HandelAbsentCommandOnclick);
            ListAttendance = new ObservableCollection<AttendanceStudent>();
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

        private void HandelSearchStudentCommandOnclick(Window window)
        {
            InitData();
        }

        private void HandelButtonSaveAttendanceCommandOnclick(Window window)
        {
            FapContext context = new FapContext();
            foreach (var att in ListAttendance)
            {
                FapAttendance fapAttendance = context.FapAttendances.FirstOrDefault(x => x.Attendanceid == att.AttendanceId);
                fapAttendance.Attendancestatus = att.Status;
                context.SaveChanges();
            }
        }
        
        private void HandelViewClassCommandCommandOnclick(Window window)
        {

            //window.Close();
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
            FapContext context = new FapContext();
            TeacherTakeClass teacherTake = SessionData._TeacherTakeClass;
            if (ListAttendance != null)
            {
                ListAttendance.Clear();
            }
            FapUser user = context.FapUsers.FirstOrDefault(x => x.Usernumber.ToLower().Equals(Rollnumber.ToLower()));
            if (user != null)
            {
                FapStudent student = context.FapStudents.FirstOrDefault(x => x.Usid == user.Userid);
                if (student != null)
                {
                    List<FapAttendance> attendance = context.FapAttendances.Where(x => x.Studentid == student.Studentid).ToList();
                    int count = 1;
                    foreach (var att in attendance)
                    {
                        if (att.Attendancedate.HasValue && att.Attendancedate.Value.Date == DateTime.Today)
                        {
                            AttendanceStudent attendanceStudent = new AttendanceStudent();
                            attendanceStudent.Number = count++;
                            attendanceStudent.AttendanceId = att.Attendanceid;
                            attendanceStudent.CourseName = context.FapCourses.FirstOrDefault(x => x.Courseid == att.Courseid).Coursekey;
                            attendanceStudent.ClassName = context.FapClasses.FirstOrDefault(x => x.Classid == att.Classid).Classname;
                            int usId = (int)context.FapStudents.FirstOrDefault(x => x.Studentid == att.Studentid).Usid;
                            FapUser us = context.FapUsers.FirstOrDefault(x => x.Userid == usId);
                            attendanceStudent.RollNumber = us.Usernumber;
                            attendanceStudent.FullName = us.Userfullname;
                            attendanceStudent.Status = (int)att.Attendancestatus;
                            ListAttendance.Add(attendanceStudent);
                        }
                    }
                }
                else
                {
                    ListAttendance = new ObservableCollection<AttendanceStudent>();
                }

            }
        }



        public event EventHandler RequestClose;

        private void CloseWindow()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
        #endregion Methods

    }
}
