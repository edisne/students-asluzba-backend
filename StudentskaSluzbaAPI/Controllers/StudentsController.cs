using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentskaSluzbaAPI.DAL;
using StudentskaSluzbaAPI.Models;
using StudentskaSluzbaAPI.Entities;

namespace StudentskaSluzbaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        //{
        //  if (_context.Students == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Students.ToListAsync();
        //}

        [HttpGet]
        public IEnumerable<StudentDTO> GetAllStudents()
        {
            if (_context.Students == null)
            {
                throw new Exception("Unable to connect to database");
            }

            List<StudentDTO> list;

            string sql = "EXEC SP_GetAllStudents";

            list = _context.StudentDTO.FromSqlRaw<StudentDTO>(sql).ToList();

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            if (_context.StudentDTO == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);
            
            student.Status = await _context.StatusStudenta.FindAsync(student.StatusStudentaId);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        //[HttpGet("{id}")]
        //public Student GetStudentById(int id)
        //{

        //    if (_context.Students == null)
        //    {
        //        throw new Exception("Error connecting to Database");
        //    }

        //    var student = new Student();
        //    string sql = "EXEC SP_SelectStudent @StudentId";
        //    List<SqlParameter> param = new List<SqlParameter>
        //    {
        //        // Create parameter(s)    
        //        new SqlParameter { ParameterName = "@StudentId", Value = id }
        //    };

        //    student = _context.Students.FromSqlRaw<Student>(sql, param.ToArray()).AsEnumerable().FirstOrDefault();


        //    if (student == null)
        //    {
        //        throw new Exception("Student not found");
        //    }

        //    return student;
        //}


        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
          if (_context.Students == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Students'  is null.");
          }
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
