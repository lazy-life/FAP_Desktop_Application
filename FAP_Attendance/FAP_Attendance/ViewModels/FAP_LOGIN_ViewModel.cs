using FAP_Attendance.Helpers;
using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
using FAP_Attendance.Managers.Model;
using FAP_Attendance.Models;
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
        private ObservableCollection<FapUser> _users;
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

        public ObservableCollection<FapUser> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }
        public FapContext context;
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
            Users = new ObservableCollection<FapUser>();
            context = new FapContext();
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
            var userLogin = context.FapUsers.Where(x => x.Usernumber.ToLower().Equals(Username.ToLower()) || x.Useremail.ToLower().Equals(Username.ToLower()) && x.Userpass.Equals(Password)).FirstOrDefault();
            if (userLogin != null)
            {
                SessionData.InitSessionData(userLogin);
                if (userLogin.Userrole == 1)
                {
                    var fap_student_home = Manager.Resolve<FAP_STUDENT_HOME_View>();
                    Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
                    fap_student_home.Show();
                }
                if (userLogin.Userrole == 2)
                {
                    var fap_teacher_home = Manager.Resolve<FAP_TEACHER_HOME_View>();
                    Task.Delay(TimeSpan.FromSeconds(AppSetting.SCREEN_TRANSITION_WAITING_TIME));
                    fap_teacher_home.Show();
                }
                if (userLogin.Userrole == 3)
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
            
        }
        #endregion Method
    }
}
