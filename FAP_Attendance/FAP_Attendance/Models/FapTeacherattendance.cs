using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapTeacherattendance
{
    public int Teacherattendanceid { get; set; }

    public int? Teacherid { get; set; }

    public int? Attendanceid { get; set; }
}
