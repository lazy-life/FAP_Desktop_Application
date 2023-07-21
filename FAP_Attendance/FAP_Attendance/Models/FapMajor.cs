using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapMajor
{
    public int Majorid { get; set; }

    public string Majorkey { get; set; }

    public string Majorname { get; set; }

    public int? Majorstatus { get; set; }
}
