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
    public class FAP_TEACHER_ATTENDANCE_ViewModel : BindableBase, IFAP_TEACHER_ATTENDANCE_ViewModel
    {
        #region Fields
        private ObservableCollection<AttendanceStudent> _listAttendance;
        private string _course;
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

        public string Course
        {
            get => _course;
            set => SetProperty(ref _course, value);
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
            FapContext context = new FapContext();
            foreach (var att in ListAttendance)
            {
                FapAttendance fapAttendance = context.FapAttendances.FirstOrDefault(x => x.Attendanceid == att.AttendanceId);
                fapAttendance.Attendancestatus = att.Status;
                context.SaveChanges();
            }
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
            FapContext context = new FapContext();
            TeacherTakeClass teacherTake = SessionData._TeacherTakeClass;
            Course = teacherTake.Subject;
            Room = teacherTake.Room;
            Slot = teacherTake.Slot;
            Date = teacherTake.Start;

            //FapClass fapClass = context.FapClasses.FirstOrDefault(x => x.Classname.Eq);
            FapCourse fapCourse = context.FapCourses.FirstOrDefault(x => x.Coursekey.Equals(Course));
            FapRoom fapRoom = context.FapRooms.FirstOrDefault(x => x.Roomname.Equals(Room));
            List<FapAttendance> attendance = context.FapAttendances.Where(x => x.Slotid == Slot
                                                                          && x.Courseid == fapCourse.Courseid
                                                                          && x.Roomid == fapRoom.Roomid).ToList();
            int count = 1;
            foreach (var att in attendance)
            {
                if (att.Attendancedate.HasValue && att.Attendancedate.Value.Date == DateTime.Today)
                {
                    AttendanceStudent attendanceStudent = new AttendanceStudent();
                    attendanceStudent.Number = count++;
                    attendanceStudent.AttendanceId = att.Attendanceid;
                    attendanceStudent.ClassName = context.FapClasses.FirstOrDefault(x => x.Classid == att.Classid).Classname;

                    FapStudent st = context.FapStudents.FirstOrDefault(x => x.Studentid == att.Studentid);
                    if(st != null)
                    {
                        int usId = (int)st.Usid;
                        FapUser us = context.FapUsers.FirstOrDefault(x => x.Userid == usId);
                        attendanceStudent.RollNumber = us.Usernumber;
                        attendanceStudent.FullName = us.Userfullname;
                        attendanceStudent.Status = (int)att.Attendancestatus;
                        ListAttendance.Add(attendanceStudent);
                    }
                    
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
