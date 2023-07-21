using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapStudentattendance
{
    public int Studentattendanceid { get; set; }

    public int? Studentid { get; set; }

    public int? Attendanceid { get; set; }
}
