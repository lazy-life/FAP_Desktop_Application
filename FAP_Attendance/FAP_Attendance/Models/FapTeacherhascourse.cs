using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapTeacherhascourse
{
    public int Teacherhascourseid { get; set; }

    public int? Teacherid { get; set; }

    public int? Courseid { get; set; }
}
