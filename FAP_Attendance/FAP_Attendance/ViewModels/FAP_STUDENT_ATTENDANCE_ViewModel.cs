using FAP_Attendance.IViewModels;
using FAP_Attendance.Models;
using PCS_APP;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;

namespace FAP_Attendance.ViewModels
{
    public class FAP_STUDENT_ATTENDANCE_ViewModel : BindableBase, IFAP_STUDENT_ATTENDANCE_ViewModel
    {
        #region Fields
        private ObservableCollection<Attendance> _attendanceStudent;
        private ObservableCollection<Course> _courseList;
        private Course _selectedCourse;
        private int _absentSlot;
        private int _presentSlot;
        private int _totalSlot;
        #endregion Fields

        #region Properties

        public Course SelectedCourse
        {
            get => _selectedCourse;
            set => SetProperty(ref _selectedCourse, value, () => LoadCourseAttendance());
        }
        public ObservableCollection<Attendance> AttendanceStudent
        {
            get => _attendanceStudent;
            set => SetProperty(ref _attendanceStudent, value);
        }
        public ObservableCollection<Course> CourseList
        {
            get => _courseList;
            set => SetProperty(ref _courseList, value);
        }

        public int AbsentSlot
        {
            get => _absentSlot;
            set => SetProperty(ref _absentSlot, value);
        }

        public int PresentSlot
        {
            get => _presentSlot;
            set => SetProperty(ref _presentSlot, value);
        }

        public int TotalSlot
        {
            get => _totalSlot;
            set => SetProperty(ref _totalSlot, value);
        }
        #endregion Properties

        #region Contractors
        public FAP_STUDENT_ATTENDANCE_ViewModel()
        {
            AttendanceStudent = new ObservableCollection<Attendance>();
            CourseList = new ObservableCollection<Course>();
            AbsentSlot = 0;
            PresentSlot = 0;
            TotalSlot = 0;
            InitData();
            InitDataCourse();
        }
        #endregion Contractors

        #region Methods
        private void InitData()
        {
            FapContext context = new FapContext();
            int idAttendance = 1;
            FapStudent student = context.FapStudents.FirstOrDefault(x => x.Usid == SessionData._User.Userid);
            FapCourse course = context.FapCourses.FirstOrDefault(x => x.CourseSemester == student.Studentsemester);
            List<FapAttendance> lstAttendance = context.FapAttendances.Where(x => x.Studentid == student.Studentid && x.Courseid == course.Courseid).ToList();
            foreach (var at in lstAttendance)
            {
                Attendance attent = new Attendance();
                attent.AttendanceId = idAttendance++;
                attent.AttendanceDate = (DateTime)at.Attendancedate;
                attent.StudentId = SessionData._User.Usernumber;
                FapTeacher teacher = context.FapTeachers.FirstOrDefault(x => x.Teacherid == at.Teacherid);
                attent.TeacherId = context.FapUsers.FirstOrDefault(x => x.Userid == teacher.Usid).Userfullname;
                attent.AttendanceStatus = (int)at.Attendancestatus;
                attent.CourseId = context.FapCourses.FirstOrDefault(x => x.Courseid == at.Courseid).Coursekey;
                attent.RoomId = context.FapRooms.FirstOrDefault(x => x.Roomid == at.Roomid).Roomname;
                attent.SlotId = (int)at.Slotid;
                AttendanceStudent.Add(attent);
            }

            foreach (var item in AttendanceStudent)
            {
                if (item.AttendanceStatus == 1)
                {
                    PresentSlot++;
                }
                if (item.AttendanceStatus == 2)
                {
                    AbsentSlot++;
                }
            }
            TotalSlot = AttendanceStudent.Count;
        }

        private void InitDataCourse()
        {
            FapContext context = new FapContext();
            FapStudent student = context.FapStudents.FirstOrDefault(x => x.Usid == SessionData._User.Userid);
            List<FapCourse> lstCourse = context.FapCourses.Where(x => x.CourseSemester == student.Studentsemester).ToList();
            foreach (var c in lstCourse)
            {
                Course course = new Course();
                course.CourseId = c.Courseid;
                course.CourseName = c.Coursename;
                course.CourseKey = c.Coursekey;
                CourseList.Add(course);
            }
        }

        private void LoadCourseAttendance()
        {
            AttendanceStudent.Clear();
            FapContext context = new FapContext();
            int idAttendance = 1;
            PresentSlot = 0;
            AbsentSlot = 0;
            TotalSlot = 0;
            FapStudent student = context.FapStudents.FirstOrDefault(x => x.Usid == SessionData._User.Userid);
            List<FapAttendance> lstAttendance = context.FapAttendances.Where(x => x.Studentid == student.Studentid && x.Courseid == SelectedCourse.CourseId).ToList();
            foreach (var at in lstAttendance)
            {
                Attendance attent = new Attendance();
                attent.AttendanceId = idAttendance++;
                attent.AttendanceDate = (DateTime)at.Attendancedate;
                attent.StudentId = SessionData._User.Usernumber;
                FapTeacher teacher = context.FapTeachers.FirstOrDefault(x => x.Teacherid == at.Teacherid);
                attent.TeacherId = context.FapUsers.FirstOrDefault(x => x.Userid == teacher.Usid).Userfullname;
                attent.AttendanceStatus = (int)at.Attendancestatus;
                attent.CourseId = context.FapCourses.FirstOrDefault(x => x.Courseid == at.Courseid).Coursekey;
                attent.RoomId = context.FapRooms.FirstOrDefault(x => x.Roomid == at.Roomid).Roomname;
                attent.SlotId = (int)at.Slotid;
                AttendanceStudent.Add(attent);
            }

            foreach (var item in AttendanceStudent)
            {
                if (item.AttendanceStatus == 1)
                {
                    PresentSlot++;
                }
                if (item.AttendanceStatus == 2)
                {
                    AbsentSlot++;
                }
            }
            TotalSlot = AttendanceStudent.Count;
        }
        #endregion Methods
    }
}
