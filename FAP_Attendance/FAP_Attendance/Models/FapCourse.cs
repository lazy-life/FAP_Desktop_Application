using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapCourse
{
    public int Courseid { get; set; }

    public string Coursename { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? Startend { get; set; }

    public int? Totalslot { get; set; }
    public string Coursekey { get; set; }
}
