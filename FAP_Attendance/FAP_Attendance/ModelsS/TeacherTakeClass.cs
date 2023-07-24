using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP_Attendance.Models
{
    public class TeacherTakeClass
    {
        public int Slot { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Subject { get; set; }
        public string ClassName { get; set; }
        public string Room { get; set; }

        public TeacherTakeClass()
        {
        }

        public TeacherTakeClass(int slot, DateTime start, DateTime end, string subject, string className, string room)
        {
            Slot = slot;
            Start = start;
            End = end;
            Subject = subject;
            ClassName = className;
            Room = room;
        }
    }
}
