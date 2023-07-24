using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP_Attendance.Models
{
    public class AttendanceStudent: BindableBase
    {
        private int _status;
        public int Number { get; set; }
        public int AttendanceId { get; set; }
        public string ClassName { get; set; }
        public string RollNumber { get; set; }
        public string  FullName { get; set; }
        public int Status {
            get => _status;
            set
            {
                SetProperty(ref _status, value);
            }
        }
        public int AbsentDay { get; set; }

        public AttendanceStudent()
        {
        }

        public AttendanceStudent(int number, string className, string rollNumber, string fullName, int status, int absentDay)
        {
            Number = number;
            ClassName = className;
            RollNumber = rollNumber;
            FullName = fullName;
            Status = status;
            AbsentDay = absentDay;
        }
    }
}
