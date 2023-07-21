using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapRoom
{
    public int Roomid { get; set; }

    public string Roomname { get; set; }

    public int? Roomstatus { get; set; }
}
