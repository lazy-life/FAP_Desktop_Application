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

namespace FAP_Attendance.ViewModels
{
    class FAP_PU_CONFIRM_EXIT_APP_ViewModel:BindableBase, IFAP_PU_CONFIRM_EXIT_APP_ViewModel
    {
        #region Commands
        public DelegateCommand<Window> ButtonExitCommand { get; set; }
        public DelegateCommand<Window> ButtonBackCommand { get; set; }
        #endregion Commands
        #region Contractor
        public FAP_PU_CONFIRM_EXIT_APP_ViewModel()
        {
            ButtonExitCommand = new DelegateCommand<Window>(HandleExitOnClick);
            ButtonBackCommand = new DelegateCommand<Window>(HandleBackOnClick);
        }
        #endregion Contractor

        #region Methods
        private void HandleExitOnClick(Window window)
        {
            Environment.Exit(0);
        }
        
        private void HandleBackOnClick(Window window)
        {
            window.Close();
        }

        #endregion Methods
    }
}
