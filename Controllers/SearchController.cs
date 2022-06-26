using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SchoolDBContext _context;

        public SearchController(SchoolDBContext context)
        {
            _context = context;
        }

        // POST: api/<SearchController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent(Student student)
        {
            List<Student> students = null;

            //Lambda Expression

            //students = await _context.Student.Select(s => new Student
            //{
            //    StudentId = s.StudentId,
            //    StudentName = s.StudentName,
            //    Contact = s.Contact,
            //    Age = s.Age,
            //    Gender = s.Gender
            //}).ToListAsync<Student>();

            //LINQ
            students = await (from s in _context.Student
                              select new Student
                              {
                                  StudentId = s.StudentId,
                                  StudentName = s.StudentName,
                                  Contact = s.Contact,
                                  Age = s.Age,
                                  Gender = s.Gender
                              }).ToListAsync<Student>();

            if (student.StudentName != null)
            {
                students = (from s in students
                            where s.StudentName.Contains(student.StudentName)
                            select s).ToList();
            }

            if (student.Age != null)
            {
                students = (from s in students
                            where s.Age < student.Age
                            select s).ToList();
            }


            return students;
        }
    }
}
