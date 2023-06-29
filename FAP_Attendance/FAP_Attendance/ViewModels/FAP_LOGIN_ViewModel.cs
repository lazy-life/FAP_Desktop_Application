using FAP_Attendance.Helpers;
using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
using FAP_Attendance.Managers.Model;
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
    public class FAP_LOGIN_ViewModel : BindableBase, IFAP_LOGIN_ViewModel
    {
        #region Fields
        private string _username;
        private string _password;
        private ObservableCollection<User> _users;
        #endregion Fields

        #region Properties
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ObservableCollection<User> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }
        #endregion Properties

        #region Commands
        public DelegateCommand<Window> LoginCommand { get; set; }
        public DelegateCommand<Window> ExitCommand { get; set; }
        #endregion Commands

        #region Contractor
        public FAP_LOGIN_ViewModel()
        {
            LoginCommand = new DelegateCommand<Window>(HandleLoginOnClick);
            ExitCommand = new DelegateCommand<Window>(HandleExitOnClick);
            Username = "";
            Password = "";
            Users = new ObservableCollection<User>();
            InitData();
        }
        #endregion Contractor

        #region Method
        private void HandleLoginOnClick(Window window)
        {
            LoginCommon(window);
        }
        private void HandleExitOnClick(Window window)
        {
            var confirm = Manager.Resolve<FAP_PU_CONFIRM_EXIT_APP>();
            confirm.ShowDialog();
        }

        private void LoginCommon(Window window)
        {
            var userLogin = Users.Where(x => x.UserName.Equals(Username) || x.UserName.Equals(Username) && x.Password.Equals(Password)).FirstOrDefault();
            if (userLogin != null)
            {
                SessionData.InitSessionData(userLogin);
                if (userLogin.Role == 1)
                {
                    var fap_student_home = Manager.Resolve<FAP_STUDENT_HOME_View>();
                    Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
                    fap_student_home.Show();
                }
                if (userLogin.Role == 2)
                {
                    var fap_teacher_home = Manager.Resolve<FAP_TEACHER_HOME_View>();
                    Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
                    fap_teacher_home.Show();
                }
                if (userLogin.Role == 3)
                {
                    var fap_manager_home = Manager.Resolve<FAP_MANAGER_HOME_View>();
                    Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
                    fap_manager_home.Show();
                }
                window.Close();
            }
            else
            {
                var loginFail = Manager.Resolve<FAP_PU_LOGIN_FAIL_View>();
                loginFail.Show();
            }
        }

        private void InitData()
        {
            Users.Add(new User
            {
                UserId = 1,
                UserCode = "he161204",
                UserName = "ducdt",
                Password = "123",
                Name = "Dao Trung Duc",
                Email = "ducdt@fpt.edu.vn",
                Role = 1
            });

            Users.Add(new User
            {
                UserId = 2,
                UserCode = "ba13",
                UserName = "hoakt3",
                Password = "123",
                Name = "Khuat Thi Hoa",
                Email = "hoakt@fpt.edu.vn",
                Role = 2
            });

            Users.Add(new User
            {
                UserId = 3,
                UserCode = "dthl",
                UserName = "dthl",
                Password = "123",
                Name = "Phong Dao Tao",
                Email = "dthl@fpt.edu.vn",
                Role = 3
            });
        }
        #endregion Method
    }
}
