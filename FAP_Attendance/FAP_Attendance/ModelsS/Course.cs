﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP_Attendance.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string  CourseName { get; set; }
        public string  CourseKey { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string  Room { get; set; }

        public Course()
        {
        }
    }
}
