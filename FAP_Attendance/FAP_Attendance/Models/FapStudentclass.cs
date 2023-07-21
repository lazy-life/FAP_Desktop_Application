using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapStudentclass
{
    public int Studentclassid { get; set; }

    public int? Studentid { get; set; }

    public int? Classid { get; set; }
}
