using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolManagement.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentTeacher = new HashSet<StudentTeacher>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<StudentTeacher> StudentTeacher { get; set; }
    }
}
