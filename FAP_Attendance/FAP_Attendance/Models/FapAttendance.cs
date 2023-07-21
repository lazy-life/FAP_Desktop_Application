using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapAttendance
{
    public int Attendanceid { get; set; }

    public DateTime? Attendancedate { get; set; }

    public int? Studentid { get; set; }

    public int? Teacherid { get; set; }

    public int? Attendancestatus { get; set; }

    public int? Courseid { get; set; }

    public int? Roomid { get; set; }

    public int? Slotid { get; set; }

    public int? Semester { get; set; }

    public int? Classid { get; set; }
}
