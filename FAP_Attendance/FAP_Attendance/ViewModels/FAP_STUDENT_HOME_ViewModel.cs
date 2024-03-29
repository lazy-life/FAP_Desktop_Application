﻿using FAP_Attendance.Helpers;
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
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;

namespace FAP_Attendance.ViewModels
{
    public class FAP_STUDENT_HOME_ViewModel : BindableBase, IFAP_STUDENT_HOME_ViewModel
    {
        #region Fields
        private ObservableCollection<TimeTable> _lstTimeTable = new ObservableCollection<TimeTable>();
        private ObservableCollection<WeeklyTimetable> _lstWeeklyTimeTable = new ObservableCollection<WeeklyTimetable>();
        private ObservableCollection<FapNotice> _lstNotice = new ObservableCollection<FapNotice>();
        #endregion Fields

        #region Properties
        public ObservableCollection<TimeTable> LstTimeTable
        {
            get => _lstTimeTable;
            set => SetProperty(ref _lstTimeTable, value);
        }

        public ObservableCollection<WeeklyTimetable> LstWeeklyTimeTable
        {
            get => _lstWeeklyTimeTable;
            set => SetProperty(ref _lstWeeklyTimeTable, value);
        }

        public ObservableCollection<FapNotice> LstNotice
        {
            get => _lstNotice;
            set => SetProperty(ref _lstNotice, value);
        }
        public FapContext context;
        #endregion Properties

        #region Commands
        public DelegateCommand<Window> AttendanceReportCommand { get; set; }
        #endregion Commands

        #region Contractor
        public FAP_STUDENT_HOME_ViewModel()
        {
            AttendanceReportCommand = new DelegateCommand<Window>(HandelAttendanceReportOnclick);
            LstTimeTable = new ObservableCollection<TimeTable>();
            LstWeeklyTimeTable = new ObservableCollection<WeeklyTimetable>();
            LstNotice = new ObservableCollection<FapNotice>();
            context = new FapContext();
            LoadData();
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


        private void LoadData()
        {
            FapContext context = new FapContext();
            FapStudent student = context.FapStudents.FirstOrDefault(x => x.Usid == SessionData._User.Userid);
            List<FapTimetable> lstTimeTable = context.FapTimetables.Where(x => x.Studentid == student.Studentid).ToList();
            foreach (var t in lstTimeTable)
            {
                
                    TimeTable timetable = new TimeTable();
                    timetable.Slot = (int)t.Slotid;
                    timetable.Course = context.FapCourses.FirstOrDefault(x => x.Courseid == t.Courseid).Coursekey;
                    timetable.Days = (int)t.Dowid + 1;
                    FapSlot slot = context.FapSlots.FirstOrDefault(x => x.Slotid == t.Slotid);
                    timetable.Time = slot.Slotstart + "-" + slot.Slotend;
                    timetable.Room = context.FapRooms.FirstOrDefault(x => x.Roomid == t.Roomid).Roomname;
                    LstTimeTable.Add(timetable);
                

            }

            foreach (var item in LstTimeTable)
            {
                WeeklyTimetable week = null;
                if (item.Slot == 1)
                {
                    week = LstWeeklyTimeTable.FirstOrDefault(x => x.Slot == 1);
                    if (week == null)
                    {
                        week = new WeeklyTimetable();
                        week.Slot = 1;
                        week.SlotTime = item.Time;
                        week.Room = item.Room;
                        if (item.Days == 2)
                        {
                            week.Monday = item.Course;
                        }
                        if (item.Days == 3)
                        {
                            week.Tuesday = item.Course;
                        }
                        if (item.Days == 4)
                        {
                            week.Wednesday = item.Course;
                        }
                        if (item.Days == 5)
                        {
                            week.Thursday = item.Course;
                        }
                        if (item.Days == 6)
                        {
                            week.Friday = item.Course;
                        }
                        if (item.Days == 7)
                        {
                            week.Saturday = item.Course;
                        }
                        LstWeeklyTimeTable.Add(week);
                    }
                    else
                    {
                        if (item.Days == 2)
                        {
                            if (week.Monday == null)
                            {
                                week.Monday = item.Course;
                            }
                        }
                        if (item.Days == 3)
                        {
                            if (week.Tuesday == null)
                            {
                                week.Thursday = item.Course;
                            }
                        }
                        if (item.Days == 4)
                        {
                            if (week.Wednesday == null)
                            {
                                week.Wednesday = item.Course;
                            }
                        }
                        if (item.Days == 5)
                        {
                            if (week.Thursday == null)
                            {
                                week.Thursday = item.Course;
                            }
                        }
                        if (item.Days == 6)
                        {
                            if (week.Friday == null)
                            {
                                week.Friday = item.Course;
                            }
                        }
                        if (item.Days == 7)
                        {
                            if (week.Saturday == null)
                            {
                                week.Saturday = item.Course;
                            }
                        }
                    }
                }

                if (item.Slot == 2)
                {
                    week = LstWeeklyTimeTable.FirstOrDefault(x => x.Slot == 2);
                    if (week == null)
                    {
                        week = new WeeklyTimetable();
                        week.Slot = 2;
                        week.SlotTime = item.Time;
                        week.Room = item.Room;
                        if (item.Days == 2)
                        {
                            week.Monday = item.Course;
                        }
                        if (item.Days == 3)
                        {
                            week.Tuesday = item.Course;
                        }
                        if (item.Days == 4)
                        {
                            week.Wednesday = item.Course;
                        }
                        if (item.Days == 5)
                        {
                            week.Thursday = item.Course;
                        }
                        if (item.Days == 6)
                        {
                            week.Friday = item.Course;
                        }
                        if (item.Days == 7)
                        {
                            week.Saturday = item.Course;
                        }
                        LstWeeklyTimeTable.Add(week);
                    }
                    else
                    {
                        if (item.Days == 2)
                        {
                            if (week.Monday == null)
                            {
                                week.Monday = item.Course;
                            }
                        }
                        if (item.Days == 3)
                        {
                            if (week.Tuesday == null)
                            {
                                week.Thursday = item.Course;
                            }
                        }
                        if (item.Days == 4)
                        {
                            if (week.Wednesday == null)
                            {
                                week.Wednesday = item.Course;
                            }
                        }
                        if (item.Days == 5)
                        {
                            if (week.Thursday == null)
                            {
                                week.Thursday = item.Course;
                            }
                        }
                        if (item.Days == 6)
                        {
                            if (week.Friday == null)
                            {
                                week.Friday = item.Course;
                            }
                        }
                        if (item.Days == 7)
                        {
                            if (week.Saturday == null)
                            {
                                week.Saturday = item.Course;
                            }
                        }
                    }
                }

                if (item.Slot == 3)
                {
                    week = LstWeeklyTimeTable.FirstOrDefault(x => x.Slot == 3);
                    if (week == null)
                    {
                        week = new WeeklyTimetable();
                        week.Slot = 3;
                        week.SlotTime = item.Time;
                        week.Room = item.Room;
                        if (item.Days == 2)
                        {
                            week.Monday = item.Course;
                        }
                        if (item.Days == 3)
                        {
                            week.Tuesday = item.Course;
                        }
                        if (item.Days == 4)
                        {
                            week.Wednesday = item.Course;
                        }
                        if (item.Days == 5)
                        {
                            week.Thursday = item.Course;
                        }
                        if (item.Days == 6)
                        {
                            week.Friday = item.Course;
                        }
                        if (item.Days == 7)
                        {
                            week.Saturday = item.Course;
                        }
                        LstWeeklyTimeTable.Add(week);
                    }
                    else
                    {
                        if (item.Days == 2)
                        {
                            if (week.Monday == null)
                            {
                                week.Monday = item.Course;
                            }
                        }
                        if (item.Days == 3)
                        {
                            if (week.Tuesday == null)
                            {
                                week.Thursday = item.Course;
                            }
                        }
                        if (item.Days == 4)
                        {
                            if (week.Wednesday == null)
                            {
                                week.Wednesday = item.Course;
                            }
                        }
                        if (item.Days == 5)
                        {
                            if (week.Thursday == null)
                            {
                                week.Thursday = item.Course;
                            }
                        }
                        if (item.Days == 6)
                        {
                            if (week.Friday == null)
                            {
                                week.Friday = item.Course;
                            }
                        }
                        if (item.Days == 7)
                        {
                            if (week.Saturday == null)
                            {
                                week.Saturday = item.Course;
                            }
                        }
                    }
                }

                if (item.Slot == 4)
                {
                    week = LstWeeklyTimeTable.FirstOrDefault(x => x.Slot == 4);
                    if (week == null)
                    {
                        week = new WeeklyTimetable();
                        week.Slot = 4;
                        week.SlotTime = item.Time;
                        week.Room = item.Room;
                        if (item.Days == 2)
                        {
                            week.Monday = item.Course;
                        }
                        if (item.Days == 3)
                        {
                            week.Tuesday = item.Course;
                        }
                        if (item.Days == 4)
                        {
                            week.Wednesday = item.Course;
                        }
                        if (item.Days == 5)
                        {
                            week.Thursday = item.Course;
                        }
                        if (item.Days == 6)
                        {
                            week.Friday = item.Course;
                        }
                        if (item.Days == 7)
                        {
                            week.Saturday = item.Course;
                        }
                        LstWeeklyTimeTable.Add(week);
                    }
                    else
                    {
                        if (item.Days == 2)
                        {
                            if (week.Monday == null)
                            {
                                week.Monday = item.Course;
                            }
                        }
                        if (item.Days == 3)
                        {
                            if (week.Tuesday == null)
                            {
                                week.Thursday = item.Course;
                            }
                        }
                        if (item.Days == 4)
                        {
                            if (week.Wednesday == null)
                            {
                                week.Wednesday = item.Course;
                            }
                        }
                        if (item.Days == 5)
                        {
                            if (week.Thursday == null)
                            {
                                week.Thursday = item.Course;
                            }
                        }
                        if (item.Days == 6)
                        {
                            if (week.Friday == null)
                            {
                                week.Friday = item.Course;
                            }
                        }
                        if (item.Days == 7)
                        {
                            if (week.Saturday == null)
                            {
                                week.Saturday = item.Course;
                            }
                        }
                    }
                }

                if (item.Slot == 5)
                {
                    week = LstWeeklyTimeTable.FirstOrDefault(x => x.Slot == 5);
                    if (week == null)
                    {
                        week = new WeeklyTimetable();
                        week.Slot = 5;
                        week.SlotTime = item.Time;
                        week.Room = item.Room;
                        if (item.Days == 2)
                        {
                            week.Monday = item.Course;
                        }
                        if (item.Days == 3)
                        {
                            week.Tuesday = item.Course;
                        }
                        if (item.Days == 4)
                        {
                            week.Wednesday = item.Course;
                        }
                        if (item.Days == 5)
                        {
                            week.Thursday = item.Course;
                        }
                        if (item.Days == 6)
                        {
                            week.Friday = item.Course;
                        }
                        if (item.Days == 7)
                        {
                            week.Saturday = item.Course;
                        }
                        LstWeeklyTimeTable.Add(week);
                    }
                    else
                    {
                        if (item.Days == 2)
                        {
                            if (week.Monday == null)
                            {
                                week.Monday = item.Course;
                            }
                        }
                        if (item.Days == 3)
                        {
                            if (week.Tuesday == null)
                            {
                                week.Thursday = item.Course;
                            }
                        }
                        if (item.Days == 4)
                        {
                            if (week.Wednesday == null)
                            {
                                week.Wednesday = item.Course;
                            }
                        }
                        if (item.Days == 5)
                        {
                            if (week.Thursday == null)
                            {
                                week.Thursday = item.Course;
                            }
                        }
                        if (item.Days == 6)
                        {
                            if (week.Friday == null)
                            {
                                week.Friday = item.Course;
                            }
                        }
                        if (item.Days == 7)
                        {
                            if (week.Saturday == null)
                            {
                                week.Saturday = item.Course;
                            }
                        }
                    }
                }

                if (item.Slot == 6)
                {
                    week = LstWeeklyTimeTable.FirstOrDefault(x => x.Slot == 6);
                    if (week == null)
                    {
                        week = new WeeklyTimetable();
                        week.Slot = 6;
                        week.SlotTime = item.Time;
                        week.Room = item.Room;
                        if (item.Days == 2)
                        {
                            week.Monday = item.Course;
                        }
                        if (item.Days == 3)
                        {
                            week.Tuesday = item.Course;
                        }
                        if (item.Days == 4)
                        {
                            week.Wednesday = item.Course;
                        }
                        if (item.Days == 5)
                        {
                            week.Thursday = item.Course;
                        }
                        if (item.Days == 6)
                        {
                            week.Friday = item.Course;
                        }
                        if (item.Days == 7)
                        {
                            week.Saturday = item.Course;
                        }
                        LstWeeklyTimeTable.Add(week);
                    }
                    else
                    {
                        if (item.Days == 2)
                        {
                            if (week.Monday == null)
                            {
                                week.Monday = item.Course;
                            }
                        }
                        if (item.Days == 3)
                        {
                            if (week.Tuesday == null)
                            {
                                week.Thursday = item.Course;
                            }
                        }
                        if (item.Days == 4)
                        {
                            if (week.Wednesday == null)
                            {
                                week.Wednesday = item.Course;
                            }
                        }
                        if (item.Days == 5)
                        {
                            if (week.Thursday == null)
                            {
                                week.Thursday = item.Course;
                            }
                        }
                        if (item.Days == 6)
                        {
                            if (week.Friday == null)
                            {
                                week.Friday = item.Course;
                            }
                        }
                        if (item.Days == 7)
                        {
                            if (week.Saturday == null)
                            {
                                week.Saturday = item.Course;
                            }
                        }
                    }
                }
            }

            foreach (var notce in context.FapNotices.ToList())
            {
                LstNotice.Add(notce);
            }
        }
        #endregion Methods
    }
}
