
namespace BlazorApp1.Server.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Classroom" },
            new Category { Id = 2, Name = "On-Demand" });

            modelBuilder.Entity<SuperCourse>().HasData(
                
            new SuperCourse
            {
                Id = 1,
                Name = "Math",
                CategoryId = 1
            }, 
            new SuperCourse
            {
                Id = 2,
                Name = "English",
                CategoryId = 1
            });
        }

        public DbSet<SuperCourse> SuperCourses { get; set; }
        public DbSet<SuperStudent> SuperStudents { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
