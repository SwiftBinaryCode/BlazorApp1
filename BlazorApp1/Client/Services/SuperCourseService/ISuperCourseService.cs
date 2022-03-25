

namespace BlazorApp1.Client.Services.SuperCourseService
{
    public interface ISuperCourseService
    {
        List<SuperCourse> Courses { get; set; }
        List<Category> Categories { get; set; }

        Task GetCategories();

        Task GetSuperCourses();
        Task CreateSuperCourses(SuperCourse course);
        Task UpdateSuperCourse(SuperCourse course);
        Task DeleteSuperCourse(int id);

        Task<SuperCourse> GetSingleCourse(int id);
    }
}
