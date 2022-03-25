using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Services.SuperStudentService
{
    public class SuperStudentService : ISuperStudentService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public SuperStudentService(HttpClient http, NavigationManager NavigationManager)
        {
            _http = http;
            _navigationManager = NavigationManager;
        }
        public List<SuperStudent> Students { get; set; }

        public async Task CreateSuperStudents(SuperStudent student)
        {
            var result = await _http.PostAsJsonAsync("api/superstudent", student);
            await SetStudent(result);
        }

        private async Task SetStudent(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<SuperStudent>>();
            Students = response;
            _navigationManager.NavigateTo("superstudents");
        }
       

        public async Task DeleteSuperStudent(int id)
        {
            var result = await _http.DeleteAsync($"api/superstudent({id}");
            await SetStudent(result);
        }

        public async Task<SuperStudent> GetSingleStudent(int id)
        {
            var result = await _http.GetFromJsonAsync<SuperStudent>($"api/superstudent/{id}");
            if (result != null)
                return result;

            throw new Exception("Student not found");
        }

        public async Task GetSuperStudents()
        {
            var result = await _http.GetFromJsonAsync<List<SuperStudent>>("api/superstudent");
            if (result != null)
                Students = result;
        }

        public async Task UpdateSuperStudent(SuperStudent student)
        {
            var result = await _http.PutAsJsonAsync($"api/superstudent({student.Id}", student);
            await SetStudent(result);
        }
    }
}
