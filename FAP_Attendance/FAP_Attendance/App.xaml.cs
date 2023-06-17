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
            return Container.Resolve<FAP_TEACHER_HOME_View>();
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
            #endregion

            Manager.Configuration(Container);
        }
    }
}
