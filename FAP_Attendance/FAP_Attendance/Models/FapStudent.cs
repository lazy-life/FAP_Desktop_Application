using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapStudent
{
    public int Studentid { get; set; }

    public string Studentk { get; set; }

    public int? Studentsemester { get; set; }

    public int? Usid { get; set; }
}
