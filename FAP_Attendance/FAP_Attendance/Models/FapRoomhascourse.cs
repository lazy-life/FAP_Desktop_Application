using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapRoomhascourse
{
    public int Roomhascourseid { get; set; }

    public int? Roomid { get; set; }

    public int? Courseid { get; set; }
}
