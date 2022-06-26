using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentTeacherController : ControllerBase
    {
        private readonly SchoolDBContext _context;

        public StudentTeacherController(SchoolDBContext context)
        {
            _context = context;
        }

        // GET: api/StudentTeacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyStudentTeacher>>> GetStudentTeacher()
        {
            List<MyStudentTeacher> studentTeachers = new List<MyStudentTeacher>();
            studentTeachers = await (from t in _context.Teacher
                                     join st in _context.StudentTeacher
                                     on t.TeacherId equals st.TeacherId
                                     select new MyStudentTeacher
                                     {
                                         StudentId = st.StudentId,
                                         Age = st.Student.Age,
                                         StudentName = st.Student.StudentName,
                                         Departement = t.Departement,
                                         TeacherId = t.TeacherId,
                                         TeacherName = t.TeacherName
                                     }).ToListAsync<MyStudentTeacher>();

            return studentTeachers;
        }

        // GET: api/StudentTeacher/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentTeacher>> GetStudentTeacher(int id)
        {
            var studentTeacher = await _context.StudentTeacher.FindAsync(id);

            if (studentTeacher == null)
            {
                return NotFound();
            }

            return studentTeacher;
        }

        // PUT: api/StudentTeacher/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentTeacher(int id, StudentTeacher studentTeacher)
        {
            if (id != studentTeacher.TeacherId)
            {
                return BadRequest();
            }

            _context.Entry(studentTeacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentTeacherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentTeacher
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentTeacher>> PostStudentTeacher(StudentTeacher studentTeacher)
        {
            _context.StudentTeacher.Add(studentTeacher);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentTeacherExists(studentTeacher.TeacherId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentTeacher", new { id = studentTeacher.TeacherId }, studentTeacher);
        }

        // DELETE: api/StudentTeacher/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentTeacher>> DeleteStudentTeacher(int id)
        {
            var studentTeacher = await _context.StudentTeacher.FindAsync(id);
            if (studentTeacher == null)
            {
                return NotFound();
            }

            _context.StudentTeacher.Remove(studentTeacher);
            await _context.SaveChangesAsync();

            return studentTeacher;
        }

        private bool StudentTeacherExists(int id)
        {
            return _context.StudentTeacher.Any(e => e.TeacherId == id);
        }
    }
}
