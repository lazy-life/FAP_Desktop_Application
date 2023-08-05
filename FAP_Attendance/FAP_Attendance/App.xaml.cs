using FAP_Attendance.Helpers;
using FAP_Attendance.IViewModels;
using FAP_Attendance.Managers;
using FAP_Attendance.ViewModels;
using FAP_Attendance.Views;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FAP_Attendance
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<FAP_Welcome_View>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Config write log
            log4net.Config.XmlConfigurator.Configure();

            #region Get data from appSettings
            if (AppSetting.InitData())
                Logger.log.Info("Get Data from appSettings.");
            else
                Logger.log.Error("Error: Get Data from appSettings.");
            #endregion

            #region ViewModel
            containerRegistry.Register<IBaseViewModel, BaseViewModel>();
            containerRegistry.Register<IFAP_LOGIN_ViewModel, FAP_LOGIN_ViewModel>();
            containerRegistry.Register<IFAP_STUDENT_HOME_ViewModel, FAP_STUDENT_HOME_ViewModel>();
            containerRegistry.Register<IFAP_UC_01ViewModel, FAP_UC_01ViewModel>();
            containerRegistry.Register<IFAP_TEACHER_HOME_ViewModel, FAP_TEACHER_HOME_ViewModel>();
            containerRegistry.Register<IFAP_PU_TEACHER_ATTENDANCE_ViewModel, FAP_PU_TEACHER_ATTENDANCE_ViewModel>();
            containerRegistry.Register<IFAP_STUDENT_ATTENDANCE_ViewModel, FAP_STUDENT_ATTENDANCE_ViewModel>();
            containerRegistry.Register<IFAP_UC_02_ViewModel, FAP_UC_02_ViewModel>();
            containerRegistry.Register<IFAP_PU_CONFIRM_EXIT_APP_ViewModel, FAP_PU_CONFIRM_EXIT_APP_ViewModel>();
            containerRegistry.Register<IFAP_PU_LOGIN_FAIL_ViewModel, FAP_PU_LOGIN_FAIL_ViewModel>();
            containerRegistry.Register<IFAP_TEACHER_ATTENDANCE_ViewModel, FAP_TEACHER_ATTENDANCE_ViewModel>();
            containerRegistry.Register<IFAP_MANAGER_HOME_ViewModel, FAP_MANAGER_HOME_ViewModel>();
            #endregion

            Manager.Configuration(Container);
        }
    }
}
