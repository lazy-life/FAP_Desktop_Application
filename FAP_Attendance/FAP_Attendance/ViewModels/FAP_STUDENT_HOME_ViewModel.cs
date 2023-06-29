using FAP_Attendance.Helpers;
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
        private ObservableCollection<Notice> _lstNotice = new ObservableCollection<Notice>();
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

        public ObservableCollection<Notice> LstNotice
        {
            get => _lstNotice;
            set => SetProperty(ref _lstNotice, value);
        }
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
            LstNotice = new ObservableCollection<Notice>();
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
            LstTimeTable.Add(new TimeTable(1, "MAD101", 2, "12:50-14:20", "DE-203"));
            LstTimeTable.Add(new TimeTable(1, "MAI101", 3, "12:50-14:20", "DE-203"));
            LstTimeTable.Add(new TimeTable(2, "PRF101", 2, "12:50-14:20", "DE-203"));
            LstTimeTable.Add(new TimeTable(3, "MAE101", 3, "12:50-14:20", "DE-203"));
            LstTimeTable.Add(new TimeTable(4, "PRU101", 3, "12:50-14:20", "DE-203"));
            LstTimeTable.Add(new TimeTable(4, "PRM101", 5, "12:50-14:20", "DE-203"));
            LstTimeTable.Add(new TimeTable(5, "", 0, "", ""));
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
                        week.SlotTime = "11:20-13:30";
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
                        week.SlotTime = "11:20-13:30";
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
                        week.SlotTime = "11:20-13:30";
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
                        week.SlotTime = "11:20-13:30";
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
                        week.SlotTime = "11:20-13:30";
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
                        week.SlotTime = "11:20-13:30";
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

            LstNotice.Add(new Notice(1, "Mở lớp Bis Block 5 học kỳ Summer 2023",
                "Phòng tổ chức và quản lý đào tạo thông báo về việc mở lớp Bis Block 5 học kỳ Summer 2023 dự kiến bắt đầu ngày 07/08/2023.", DateTime.Parse("11/09/2022")));

            LstNotice.Add(new Notice(1, "Thông báo điểm thi kết thúc học phần lần 2 các môn KRL112, JPD216, JPD316 học kỳ Summer 2023",
                "Phòng Khảo thí thông báo đã có điểm thi kết thúc học phần lần 2 các môn KRL112, JPD216, JPD316 học kỳ Summer 2023, " +
                "các em đăng nhập FAP để xem điểm chi tiết.", DateTime.Parse("11/09/2022")));

            LstNotice.Add(new Notice(1, "THÔNG BÁO HỌC PHÍ KỲ SUMMER 2023",
                "Ban Kế toán gửi tới các bạn sinh viên thông tin về học phí kỳ SUMMER 2023 H2", DateTime.Parse("11/09/2022")));

            LstNotice.Add(new Notice(1, "THÔNG BÁO HỌC PHÍ KỲ SUMMER 2023",
                "Ban Kế toán gửi tới các bạn sinh viên thông tin về học phí kỳ SUMMER 2023 H2", DateTime.Parse("11/09/2022")));

            LstNotice.Add(new Notice(1, "Thông báo lịch thi kết thúc học phần lần 1 và lần 2 các môn kết thúc sớm của học kỳ Summer 2023.",
                "Phòng khảo thí thông báo đã có lịch thi kết thúc học phần lần 1 và lần 2 các môn kết thúc sớm của học kỳ Summer 2023. Các em đăng nhập fap.fpt.edu.vn (phần View exam schedule " +
                "(Xem lịch thi) ) để xem lịch thi và phòng thi lần 1 của mình.", DateTime.Parse("11/09/2022")));

            LstNotice.Add(new Notice(1, "THÔNG BÁO HỌC PHÍ KỲ SUMMER 2023",
                "Ban Kế toán gửi tới các bạn sinh viên thông tin về học phí kỳ SUMMER 2023 H2", DateTime.Parse("11/09/2022")));

            LstNotice.Add(new Notice(1, "THÔNG BÁO HỌC PHÍ KỲ SUMMER 2023",
                "Ban Kế toán gửi tới các bạn sinh viên thông tin về học phí kỳ SUMMER 2023 H2", DateTime.Parse("11/09/2022")));
        }
        #endregion Methods
    }
}
