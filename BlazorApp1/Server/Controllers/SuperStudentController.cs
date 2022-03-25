using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperStudentController : ControllerBase
    {
        private readonly DataContext _context;

        public static List<SuperStudent> students = new List<SuperStudent> {
                new SuperStudent {Id = 1, Name = "Will",Email="happy@gmail.com"},
                new SuperStudent {Id = 2, Name = "Bob",Email="Sad@gmail.com"}

        };
        public SuperStudentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperStudent>>> GetSuperStudents()
        {
            var student = await _context.SuperStudents.ToListAsync();
            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperStudent>> GetSingleStudent(int id)
        {
            var course = await _context.SuperStudents.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null)
            {
                return NotFound("Student not found");
            }

            return Ok(course);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperStudent>>> CreateSuperStudent(SuperStudent student)
        {
           

            _context.SuperStudents.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await GetDbStudents());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperStudent>>> UpdateSuperStudent(SuperStudent student, int id)
        {
            var dbstudent = await _context.SuperStudents.FirstOrDefaultAsync(c => c.Id == id);
            if (dbstudent == null)
                return NotFound("Sorry,No Student for you");

            dbstudent.Name = student.Name;
            dbstudent.Email = student.Email;


            await _context.SaveChangesAsync();

            return Ok(await GetDbStudents());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperStudent>>> DeleteSuperStudent(int id)
        {
            var dbstudent = await _context.SuperStudents.FirstOrDefaultAsync(c => c.Id == id);
            if (dbstudent == null)
                return NotFound("Sorry,No course for you");

            _context.SuperStudents.Remove(dbstudent);
            await _context.SaveChangesAsync();

            return Ok(await GetDbStudents());
        }

        private async Task<List<SuperStudent>> GetDbStudents()
        {
            return await _context.SuperStudents.ToListAsync();
        }
    }
}
