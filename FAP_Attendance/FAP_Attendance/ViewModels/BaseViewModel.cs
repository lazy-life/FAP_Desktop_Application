using FAP_Attendance.IViewModels;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP_Attendance.ViewModels
{
    public class BaseViewModel : BindableBase, IBaseViewModel
    {
        #region Fields
        protected readonly IEventAggregator _eventAggregator;
        #endregion

        #region Constructor
        public BaseViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        #endregion
    }
}
