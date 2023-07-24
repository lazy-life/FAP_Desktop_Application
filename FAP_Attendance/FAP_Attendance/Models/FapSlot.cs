using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapSlot
{
    public int Slotid { get; set; }

    public string Slotname { get; set; }

    public string Slotstart { get; set; }

    public string Slotend { get; set; }
}
