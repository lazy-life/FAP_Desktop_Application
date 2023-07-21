using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP_Attendance.Models
{
    public class TakeAttendance
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string RollNumber { get; set; }
        public string  Fullname { get; set; }
        public int Status { get; set; }
        public int AbsentDay { get; set; }

        public TakeAttendance(int id, string className, string rollNumber, string fullname, int status, int absentDay)
        {
            Id = id;
            ClassName = className;
            RollNumber = rollNumber;
            Fullname = fullname;
            Status = status;
            AbsentDay = absentDay;
        }
    }
}
