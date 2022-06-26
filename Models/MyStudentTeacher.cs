using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class MyStudentTeacher
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int? Age { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Departement { get; set; }
    }
}
