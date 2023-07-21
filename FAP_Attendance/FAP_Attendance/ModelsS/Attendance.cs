using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP_Attendance.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string StudentId { get; set; }
        public string TeacherId { get; set; }
        public int AttendanceStatus { get; set; }
        public string CourseId { get; set; }
        public string RoomId { get; set; }
        public int SlotId { get; set; }

        public Attendance(int attendanceId, DateTime attendanceDate, string studentId, string teacherId, int attendanceStatus, string courseId, string roomId, int slotId)
        {
            AttendanceId = attendanceId;
            AttendanceDate = attendanceDate;
            StudentId = studentId;
            TeacherId = teacherId;
            AttendanceStatus = attendanceStatus;
            CourseId = courseId;
            RoomId = roomId;
            SlotId = slotId;
        }
    }
}
