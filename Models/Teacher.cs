using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolManagement.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            StudentTeacher = new HashSet<StudentTeacher>();
        }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Departement { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<StudentTeacher> StudentTeacher { get; set; }
    }
}
