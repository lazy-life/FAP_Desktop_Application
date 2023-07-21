using System;
using System.Collections.Generic;

namespace FAP_Attendance.Models;

public partial class FapUser
{
    public int Userid { get; set; }

    public string Userfullname { get; set; }

    public string Usernumber { get; set; }

    public string Useraddress { get; set; }

    public DateTime? Userdob { get; set; }

    public string Useremail { get; set; }

    public string Userpass { get; set; }

    public DateTime? Userdatestart { get; set; }

    public DateTime? Userdateend { get; set; }

    public int? Usermajor { get; set; }

    public int? Userstatus { get; set; }

    public int? Userrole { get; set; }
}
