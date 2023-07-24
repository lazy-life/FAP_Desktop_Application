using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FAP_Attendance.Models;

public partial class FapContext : DbContext
{
    public FapContext()
    {
    }

    public FapContext(DbContextOptions<FapContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FapAttendance> FapAttendances { get; set; }

    public virtual DbSet<FapClass> FapClasses { get; set; }

    public virtual DbSet<FapCourse> FapCourses { get; set; }

    public virtual DbSet<FapCourseattendance> FapCourseattendances { get; set; }

    public virtual DbSet<FapDayofweek> FapDayofweeks { get; set; }

    public virtual DbSet<FapMajor> FapMajors { get; set; }

    public virtual DbSet<FapMajorhascourse> FapMajorhascourses { get; set; }

    public virtual DbSet<FapManager> FapManagers { get; set; }

    public virtual DbSet<FapNotice> FapNotices { get; set; }

    public virtual DbSet<FapRoom> FapRooms { get; set; }

    public virtual DbSet<FapRoomhascourse> FapRoomhascourses { get; set; }

    public virtual DbSet<FapSlot> FapSlots { get; set; }

    public virtual DbSet<FapStudent> FapStudents { get; set; }

    public virtual DbSet<FapStudentattendance> FapStudentattendances { get; set; }

    public virtual DbSet<FapStudentclass> FapStudentclasses { get; set; }

    public virtual DbSet<FapTeacher> FapTeachers { get; set; }

    public virtual DbSet<FapTeacherattendance> FapTeacherattendances { get; set; }

    public virtual DbSet<FapTeacherhascourse> FapTeacherhascourses { get; set; }

    public virtual DbSet<FapTimetable> FapTimetables { get; set; }

    public virtual DbSet<FapUser> FapUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer("server=TRUNGDUC\\SQLEXPRESS; database =FAP;uid=sa;pwd=koios; Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FapAttendance>(entity =>
        {
            entity.HasKey(e => e.Attendanceid).HasName("PK__fap_atte__0FE7007EAEAC5076");

            entity.ToTable("fap_attendance");

            entity.Property(e => e.Attendanceid).HasColumnName("attendanceid");
            entity.Property(e => e.Attendancedate)
                .HasColumnType("datetime")
                .HasColumnName("attendancedate");
            entity.Property(e => e.Attendancestatus).HasColumnName("attendancestatus");
            entity.Property(e => e.Classid).HasColumnName("classid");
            entity.Property(e => e.Courseid).HasColumnName("courseid");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.Slotid).HasColumnName("slotid");
            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Teacherid).HasColumnName("teacherid");
        });

        modelBuilder.Entity<FapClass>(entity =>
        {
            entity.HasKey(e => e.Classid).HasName("PK__fap_clas__757438061ECE33BD");

            entity.ToTable("fap_class");

            entity.Property(e => e.Classid).HasColumnName("classid");
            entity.Property(e => e.Classname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("classname");
        });

        modelBuilder.Entity<FapCourse>(entity =>
        {
            entity.HasKey(e => e.Courseid).HasName("PK__fap_cour__2AAB4BC9DA589CC5");

            entity.ToTable("fap_course");

            entity.Property(e => e.Courseid).HasColumnName("courseid");
            entity.Property(e => e.Coursename)
                .HasMaxLength(100)
                .HasColumnName("coursename");
            entity.Property(e => e.Startdate)
                .HasColumnType("datetime")
                .HasColumnName("startdate");
            entity.Property(e => e.Startend)
                .HasColumnType("datetime")
                .HasColumnName("startend");
            entity.Property(e => e.Totalslot).HasColumnName("totalslot");
            entity.Property(e => e.Coursekey).HasColumnName("coursekey");
            entity.Property(e => e.CourseSemester).HasColumnName("courseSemester");
        });

        modelBuilder.Entity<FapCourseattendance>(entity =>
        {
            entity.HasKey(e => e.Courseattendanceid).HasName("PK__fap_cour__123A526C7602DA02");

            entity.ToTable("fap_courseattendance");

            entity.Property(e => e.Courseattendanceid).HasColumnName("courseattendanceid");
            entity.Property(e => e.Attendanceid).HasColumnName("attendanceid");
            entity.Property(e => e.Courseid).HasColumnName("courseid");
        });

        modelBuilder.Entity<FapDayofweek>(entity =>
        {
            entity.HasKey(e => e.Dowid).HasName("PK__fap_dayo__B51C640381F0A453");

            entity.ToTable("fap_dayofweek");

            entity.Property(e => e.Dowid).HasColumnName("dowid");
            entity.Property(e => e.Downame)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("downame");
        });

        modelBuilder.Entity<FapMajor>(entity =>
        {
            entity.HasKey(e => e.Majorid).HasName("PK__fap_majo__A5B2A89CE89E1378");

            entity.ToTable("fap_major");

            entity.Property(e => e.Majorid).HasColumnName("majorid");
            entity.Property(e => e.Majorkey)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("majorkey");
            entity.Property(e => e.Majorname)
                .HasMaxLength(200)
                .HasColumnName("majorname");
            entity.Property(e => e.Majorstatus).HasColumnName("majorstatus");
        });

        modelBuilder.Entity<FapMajorhascourse>(entity =>
        {
            entity.HasKey(e => e.Majorhascourseid).HasName("PK__fap_majo__AB184A90679965BA");

            entity.ToTable("fap_majorhascourse");

            entity.Property(e => e.Majorhascourseid).HasColumnName("majorhascourseid");
            entity.Property(e => e.Courseid).HasColumnName("courseid");
            entity.Property(e => e.Majorid).HasColumnName("majorid");
        });

        modelBuilder.Entity<FapManager>(entity =>
        {
            entity.HasKey(e => e.Managerid).HasName("PK__fap_mana__47E11837E8C924C7");

            entity.ToTable("fap_manager");

            entity.Property(e => e.Managerid).HasColumnName("managerid");
            entity.Property(e => e.Usid).HasColumnName("usid");
        });

        modelBuilder.Entity<FapNotice>(entity =>
        {
            entity.HasKey(e => e.Noticeid).HasName("PK__fap_noti__4ED022461BD50FDF");

            entity.ToTable("fap_notice");

            entity.Property(e => e.Noticeid).HasColumnName("noticeid");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Logdate)
                .HasColumnType("datetime")
                .HasColumnName("logdate");
            entity.Property(e => e.Managerid).HasColumnName("managerid");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });

        modelBuilder.Entity<FapRoom>(entity =>
        {
            entity.HasKey(e => e.Roomid).HasName("PK__fap_room__6CC40996F73C4696");

            entity.ToTable("fap_room");

            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Roomname)
                .HasMaxLength(50)
                .HasColumnName("roomname");
            entity.Property(e => e.Roomstatus).HasColumnName("roomstatus");
        });

        modelBuilder.Entity<FapRoomhascourse>(entity =>
        {
            entity.HasKey(e => e.Roomhascourseid).HasName("PK__fap_room__EAEFC0236DDA7951");

            entity.ToTable("fap_roomhascourse");

            entity.Property(e => e.Roomhascourseid).HasColumnName("roomhascourseid");
            entity.Property(e => e.Courseid).HasColumnName("courseid");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
        });

        modelBuilder.Entity<FapSlot>(entity =>
        {
            entity.HasKey(e => e.Slotid).HasName("PK__fap_slot__9C4B6B2BFDAB51AD");

            entity.ToTable("fap_slot");

            entity.Property(e => e.Slotid).HasColumnName("slotid");
            entity.Property(e => e.Slotend)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("slotend");
            entity.Property(e => e.Slotname)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("slotname");
            entity.Property(e => e.Slotstart)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("slotstart");
        });

        modelBuilder.Entity<FapStudent>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("PK__fap_stud__4D16D264B8D862A3");

            entity.ToTable("fap_student");

            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Studentk)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("studentk");
            entity.Property(e => e.Studentsemester).HasColumnName("studentsemester");
            entity.Property(e => e.Usid).HasColumnName("usid");
        });

        modelBuilder.Entity<FapStudentattendance>(entity =>
        {
            entity.HasKey(e => e.Studentattendanceid).HasName("PK__fap_stud__687372316E379210");

            entity.ToTable("fap_studentattendance");

            entity.Property(e => e.Studentattendanceid).HasColumnName("studentattendanceid");
            entity.Property(e => e.Attendanceid).HasColumnName("attendanceid");
            entity.Property(e => e.Studentid).HasColumnName("studentid");
        });

        modelBuilder.Entity<FapStudentclass>(entity =>
        {
            entity.HasKey(e => e.Studentclassid).HasName("PK__fap_stud__A33D5E498C776A6D");

            entity.ToTable("fap_studentclass");

            entity.Property(e => e.Studentclassid).HasColumnName("studentclassid");
            entity.Property(e => e.Classid).HasColumnName("classid");
            entity.Property(e => e.Studentid).HasColumnName("studentid");
        });

        modelBuilder.Entity<FapTeacher>(entity =>
        {
            entity.HasKey(e => e.Teacherid).HasName("PK__fap_teac__98EA44AD3BE2BFFF");

            entity.ToTable("fap_teacher");

            entity.Property(e => e.Teacherid).HasColumnName("teacherid");
            entity.Property(e => e.Usid).HasColumnName("usid");
        });

        modelBuilder.Entity<FapTeacherattendance>(entity =>
        {
            entity.HasKey(e => e.Teacherattendanceid).HasName("PK__fap_teac__4B325A414EC5A570");

            entity.ToTable("fap_teacherattendance");

            entity.Property(e => e.Teacherattendanceid).HasColumnName("teacherattendanceid");
            entity.Property(e => e.Attendanceid).HasColumnName("attendanceid");
            entity.Property(e => e.Teacherid).HasColumnName("teacherid");
        });

        modelBuilder.Entity<FapTeacherhascourse>(entity =>
        {
            entity.HasKey(e => e.Teacherhascourseid).HasName("PK__fap_teac__C9796AC9794B5468");

            entity.ToTable("fap_teacherhascourse");

            entity.Property(e => e.Teacherhascourseid).HasColumnName("teacherhascourseid");
            entity.Property(e => e.Courseid).HasColumnName("courseid");
            entity.Property(e => e.Teacherid).HasColumnName("teacherid");
        });

        modelBuilder.Entity<FapTimetable>(entity =>
        {
            entity.HasKey(e => e.Timetableid).HasName("PK__fap_time__8AA6715C9211B5F2");

            entity.ToTable("fap_timetable");

            entity.Property(e => e.Timetableid).HasColumnName("timetableid");
            entity.Property(e => e.Classid).HasColumnName("classid");
            entity.Property(e => e.Dowid).HasColumnName("dowid");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Slotid).HasColumnName("slotid");
            entity.Property(e => e.Courseid).HasColumnName("courseid");
            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Teacherid).HasColumnName("teacherid");
            entity.Property(e => e.Timetabledate)
                .HasColumnType("datetime")
                .HasColumnName("timetabledate");
        });

        modelBuilder.Entity<FapUser>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__fap_user__CBA1B257BE6AD98D");

            entity.ToTable("fap_user");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Useraddress)
                .HasMaxLength(500)
                .HasColumnName("useraddress");
            entity.Property(e => e.Userdateend)
                .HasColumnType("datetime")
                .HasColumnName("userdateend");
            entity.Property(e => e.Userdatestart)
                .HasColumnType("datetime")
                .HasColumnName("userdatestart");
            entity.Property(e => e.Userdob)
                .HasColumnType("datetime")
                .HasColumnName("userdob");
            entity.Property(e => e.Useremail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("useremail");
            entity.Property(e => e.Userfullname)
                .HasMaxLength(100)
                .HasColumnName("userfullname");
            entity.Property(e => e.Usermajor).HasColumnName("usermajor");
            entity.Property(e => e.Usernumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usernumber");
            entity.Property(e => e.Userpass)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("userpass");
            entity.Property(e => e.Userrole).HasColumnName("userrole");
            entity.Property(e => e.Userstatus).HasColumnName("userstatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
