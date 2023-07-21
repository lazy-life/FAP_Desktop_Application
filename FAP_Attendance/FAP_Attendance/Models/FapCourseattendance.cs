using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapCourseattendance
{
    public int Courseattendanceid { get; set; }

    public int? Courseid { get; set; }

    public int? Attendanceid { get; set; }
}
