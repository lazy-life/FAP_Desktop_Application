using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP_Attendance.Models
{
    public class TimeTable
    {
        public int Slot { get; set; }
        public string Course { get; set; }
        public int Days { get; set; }
        public string Time { get; set; }
        public string Room { get; set; }

        public TimeTable(int slot, string course, int days, string time, string room)
        {
            Slot = slot;
            Course = course;
            Days = days;
            Time = time;
            Room = room;
        }
    }
}
