using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FAP_Attendance.Managers.Converter
{
    public class ConvertSlotToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int slot = (int)value;
            if (slot == 1)
            {
                return "Slot 1";
            }
            if (slot == 2)
            {
                return "Slot 2";
            }
            if (slot == 3)
            {
                return "Slot 3";
            }
            if (slot == 4)
            {
                return "Slot 4";
            }
            return "Slot 5";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
