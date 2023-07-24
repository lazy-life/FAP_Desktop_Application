﻿using FAP_Attendance.IViewModels;
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
        private int _absentSlot;
        private int _presentSlot;
        private int _totalSlot;
        #endregion Fields

        #region Properties
        public ObservableCollection<Attendance> AttendanceStudent
        {
            get => _attendanceStudent;
            set => SetProperty(ref _attendanceStudent, value);
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
            AbsentSlot = 0;
            PresentSlot = 0;
            TotalSlot = 0;
            InitData();
        }
        #endregion Contractors

        #region Methods
        private void InitData()
        {
            FapContext context = new FapContext();
            int idAttendance = 1;
            FapStudent student = context.FapStudents.FirstOrDefault(x => x.Usid == SessionData._User.Userid);
            List<FapAttendance> lstAttendance = context.FapAttendances.Where(x => x.Studentid == student.Studentid).ToList();
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
            //AttendanceStudent.Add(new Attendance(
            //    1,
            //    DateTime.Parse("2023-6-19"),
            //    SessionData._User.Usernumber,
            //    "ChiLP",
            //    1,
            //    "PRN221",
            //    "DE-123",
            //    1));

            //AttendanceStudent.Add(new Attendance(
            //    2,
            //    DateTime.Now,
            //    SessionData._User.Usernumber,
            //    "ChiLP",
            //    2,
            //    "PRN221",
            //    "DE-123",
            //    2));
            //AttendanceStudent.Add(new Attendance(
            //    3,
            //    DateTime.Parse("2022-11-11"),
            //    SessionData._User.Usernumber,
            //    "ChiLP",
            //    0,
            //    "PRN221",
            //    "DE-123",
            //    1));

            //AttendanceStudent.Add(new Attendance(
            //    4,
            //    DateTime.Parse("2022-12-11"),
            //    SessionData._User.Usernumber,
            //    "ChiLP",
            //    1,
            //    "PRN221",
            //    "DE-123",
            //    1));
            //AttendanceStudent.Add(new Attendance(
            //    5,
            //    DateTime.Parse("2022-12-10"),
            //    SessionData._User.Usernumber,
            //    "ChiLP",
            //    2,
            //    "PRN221",
            //    "DE-123",
            //    1));

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
