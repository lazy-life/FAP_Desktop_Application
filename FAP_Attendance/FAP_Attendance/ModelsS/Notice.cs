using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP_Attendance.Models
{
    public class Notice
    {
        public int NoticeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }

        public Notice(int noticeId, string title, string content, DateTime createAt)
        {
            NoticeId = noticeId;
            Title = title;
            Content = content;
            CreateAt = createAt;
        }
    }
}
