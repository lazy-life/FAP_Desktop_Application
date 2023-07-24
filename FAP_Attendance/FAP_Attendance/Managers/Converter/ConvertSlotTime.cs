using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FAP_Attendance.Managers.Converter
{
    public class ConvertSlotTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int slot = (int)value;
            if(slot == 1)
            {
                return "(7:30 - 9:50)";
            }
            if (slot == 2)
            {
                return "(10:00 - 12:20)";
            }
            if (slot == 3)
            {
                return "(12:50 - 15:10)";
            }
            if (slot == 4)
            {
                return "(15:20 - 17:40)";
            }
            return "(18:00 - 21:00)";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
