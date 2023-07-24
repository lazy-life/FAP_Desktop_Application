using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP_Attendance.Models
{
    public class WeeklyTimetable
    {
        public int Slot { get; set; }
        public string SlotTime { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Room { get; set; }

        public WeeklyTimetable(int slot, string slotTime, string monday, string tuesday, string wednesday, string thursday, string friday, string saturday, string room)
        {
            Slot = slot;
            SlotTime = slotTime;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;
            Room = room;
        }

        public WeeklyTimetable()
        {
        }
    }
}
