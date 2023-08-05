using FAP_Attendance.Helpers;
using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
using FAP_Attendance.Models;
using FAP_Attendance.Views;
using PCS_APP;
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
    public class FAP_PU_TEACHER_ATTENDANCE_ViewModel : BindableBase, IFAP_PU_TEACHER_ATTENDANCE_ViewModel
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
            SessionData.InitSessionData(selectedItem);
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
                if (tt.Timetabledate.HasValue && tt.Timetabledate.Value.Date == DateTime.Today)
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
        }

        public event EventHandler RequestClose;

        private void CloseWindow()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
        #endregion Methods
    }
}
