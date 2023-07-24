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
    public class FAP_TEACHER_HOME_ViewModel: BindableBase, IFAP_TEACHER_HOME_ViewModel
    {
        #region Commands
        public DelegateCommand<Window> TakeAttendanceCommand { get; set; }
        private ObservableCollection<TeacherTakeClass> _listClassTakeAttendance;
        private TeacherTakeClass _selectedTeacher;
        private ObservableCollection<TimeTable> _lstTimeTable = new ObservableCollection<TimeTable>();
        private ObservableCollection<WeeklyTimetable> _lstWeeklyTimeTable = new ObservableCollection<WeeklyTimetable>();
        public static Window Windows;
        public ObservableCollection<TeacherTakeClass> ListClassTakeAttendance
        {
            get => _listClassTakeAttendance;
            set
            {
                SetProperty(ref _listClassTakeAttendance, value);
            }
        }

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
        public TeacherTakeClass SelectedTeacher
        {
            get => _selectedTeacher;
            set => SetProperty(ref _selectedTeacher, value);
        }
        public DelegateCommand<TeacherTakeClass> GetSelectedItem { get; set; }
        public FapContext context;
        #endregion Commands

        #region Contractor
        public FAP_TEACHER_HOME_ViewModel()
        {
            TakeAttendanceCommand = new DelegateCommand<Window>(HandleTakeAttendanceOnClick);
            ListClassTakeAttendance = new ObservableCollection<TeacherTakeClass>();
            GetSelectedItem = new DelegateCommand<TeacherTakeClass>(HandelGetSelectedItemOnclick);
            LstTimeTable = new ObservableCollection<TimeTable>();
            LstWeeklyTimeTable = new ObservableCollection<WeeklyTimetable>();
            context = new FapContext();
            LoadData();
            InitData();
        }
        #endregion Contractor

        #region Method
        private void HandleTakeAttendanceOnClick(Window window)
        {
            TakeAttendanceCommon(window);
        }

        private void HandelGetSelectedItemOnclick(TeacherTakeClass selectedItem)
        {
            // Find the item with the specified ID
            SelectedTeacher = selectedItem;
            SessionData.InitSessionData(selectedItem);
            //save model to sesstion and get it when move next window
            var takeAttendance = Manager.Resolve<FAP_TEACHER_ATTENDANCE_View>();
            takeAttendance.Show();
            CloseWindow();
        }

        private void TakeAttendanceCommon(Window window)
        {
            var fap_teacher_attendance = Manager.Resolve<FAP_PU_TEACHER_ATTENDANCE_View>();
            Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
            FAP_PU_TEACHER_ATTENDANCE_ViewModel.Windows = window;
            fap_teacher_attendance.ShowDialog();
        }

        public event EventHandler RequestClose;

        private void InitData()
        {
            FapContext context = new FapContext();
            FapTeacher us = context.FapTeachers.FirstOrDefault(x => x.Usid == SessionData._User.Userid);
            var distinctTimeTables = context.FapTimetables
                                    .Where(tt => tt.Teacherid == us.Teacherid)
                                    .Select(tt => new
                                    {
                                        tt.Classid,
                                        tt.Slotid,
                                        tt.Roomid,
                                        tt.Courseid,
                                        tt.Timetabledate
                                    })
                                    .Distinct()
                                    .ToList();
            foreach (var tt in distinctTimeTables)
            {
                TeacherTakeClass teacherTake = new TeacherTakeClass();
                teacherTake.Slot = (int)tt.Slotid;
                teacherTake.StartTime = context.FapSlots.FirstOrDefault(x => x.Slotid == tt.Slotid).Slotstart;
                teacherTake.EndTime = context.FapSlots.FirstOrDefault(x => x.Slotid == tt.Slotid).Slotend;
                teacherTake.Subject = context.FapCourses.FirstOrDefault(x => x.Courseid == tt.Courseid).Coursekey;
                teacherTake.ClassName = context.FapClasses.FirstOrDefault(x => x.Classid == tt.Classid).Classname;
                teacherTake.Room = context.FapRooms.FirstOrDefault(x => x.Roomid == tt.Roomid).Roomname;
                teacherTake.Start = (DateTime)tt.Timetabledate;
                ListClassTakeAttendance.Add(teacherTake);
            }
        }

        private void LoadData()
        {
            FapContext context = new FapContext();
            FapTeacher student = context.FapTeachers.FirstOrDefault(x => x.Usid == SessionData._User.Userid);
            List<FapTimetable> lstTimeTable = context.FapTimetables.Where(x => x.Teacherid == student.Teacherid).ToList();
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
        }
        public void CloseWindow()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
        #endregion Method
    }
}
