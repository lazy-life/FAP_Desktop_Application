using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapTimetable
{
    public int Timetableid { get; set; }

    public DateTime? Timetabledate { get; set; }

    public int? Classid { get; set; }

    public int? Teacherid { get; set; }

    public int? Studentid { get; set; }

    public int? Slotid { get; set; }

    public int? Roomid { get; set; }

    public int? Dowid { get; set; }
}
