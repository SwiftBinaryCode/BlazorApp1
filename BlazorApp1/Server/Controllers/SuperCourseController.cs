using BlazorApp1.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperCourseController : ControllerBase
    {
        private readonly DataContext _context;

        //        public static List<Category> categories = new List<Category> {
        //        new Category {Id = 1, Name = "Classroom"},
        //        new Category {Id = 2, Name = "On-Demand"}
        //};

        //            public static List<SuperCourse> courses = new List<SuperCourse> {
        //            new SuperCourse {Id = 1, 
        //            Name = "Math",
        //            Category = categories[0],
        //            CategoryId=1}};

        public SuperCourseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperCourse>>> GetSuperCourses()
        {
            var courses = await _context.SuperCourses.ToListAsync();
            return Ok(courses);
        }


        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperCourse>> GetSingleCourses(int id)
        {
            var course = await _context.SuperCourses.
                Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (course == null)
            {
                return NotFound("Course not found");
            }

            return Ok(course);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperCourse>>> CreateSuperCourse(SuperCourse course)
        {
            course.Category = null;

            _context.SuperCourses.Add(course);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCourses());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperCourse>>>  UpdateSuperCourse(SuperCourse course, int id)
        {
            var dbcourse = await _context.SuperCourses.
                Include(c => c.Category).
                FirstOrDefaultAsync(c => c.Id == id);
            if (dbcourse == null)
                return NotFound("Sorry,No course for you");

            dbcourse.Name = course.Name;
            dbcourse.CategoryId = course.CategoryId;


            await _context.SaveChangesAsync();

            return Ok(await GetDbCourses());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperCourse>>> DeleteSuperCourse(int id)
        {
            var dbcourse = await _context.SuperCourses.
                Include(c => c.Category).
                FirstOrDefaultAsync(c => c.Id == id);
            if (dbcourse == null)
                return NotFound("Sorry,No course for you");

            _context.SuperCourses.Remove(dbcourse);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCourses());
        }

        private async Task<List<SuperCourse>> GetDbCourses()
        {
            return await _context.SuperCourses.Include(c => c.Category).ToListAsync();
        }

    }
}
