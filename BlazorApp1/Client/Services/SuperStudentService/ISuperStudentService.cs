namespace BlazorApp1.Client.Services.SuperStudentService
{
    public interface ISuperStudentService
    {
        List<SuperStudent> Students { get; set; }
       
        Task GetSuperStudents();
        Task CreateSuperStudents(SuperStudent student);
        Task UpdateSuperStudent(SuperStudent student);
        Task DeleteSuperStudent(int id);
        Task<SuperStudent> GetSingleStudent(int id);
    }
}
