using FAP_Attendance.IViewModels;
using FAP_Attendance.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FAP_Attendance.ViewModels
{
    class FAP_PU_LOGIN_FAIL_ViewModel: BindableBase, IFAP_PU_LOGIN_FAIL_ViewModel
    {
        #region Commands
        public DelegateCommand<Window> ButtonExitCommand { get; set; }
        public DelegateCommand<Window> ButtonTryAgainCommand { get; set; }
        #endregion Commands
        #region Contractor
        public FAP_PU_LOGIN_FAIL_ViewModel()
        {
            ButtonExitCommand = new DelegateCommand<Window>(HandleExitOnClick);
            ButtonTryAgainCommand = new DelegateCommand<Window>(HandleTryAgainOnClick);
        }
        #endregion Contractor

        #region Methods
        private void HandleExitOnClick(Window window)
        {
            Environment.Exit(0);
        }

        private void HandleTryAgainOnClick(Window window)
        {
            window.Close();
        }

        #endregion Methods
    }
}
