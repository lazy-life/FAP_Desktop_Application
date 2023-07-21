using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapNotice
{
    public int Noticeid { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime? Logdate { get; set; }

    public int? Managerid { get; set; }
}
