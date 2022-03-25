using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Services.SuperCourseService
{
    public class SuperCourseService : ISuperCourseService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public SuperCourseService(HttpClient http, NavigationManager NavigationManager)
        {
           _http = http;
           _navigationManager = NavigationManager;
        }
        public List<SuperCourse> Courses { get; set; } = new List<SuperCourse>();
        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task CreateSuperCourses(SuperCourse course)
        {
            var result = await _http.PostAsJsonAsync("api/supercourse", course);
            await SetCourse(result);
        }

        private async Task SetCourse(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<SuperCourse>>();
            Courses = response;
            _navigationManager.NavigateTo("supercourses");
        }

        public async Task DeleteSuperCourse(int id)
        {
            var result = await _http.DeleteAsync($"api/supercourse({id}");
            await SetCourse(result);
        }

        public async Task GetCategories()
        {
            var result = await _http.GetFromJsonAsync<List<Category>>("api/supercourse/categories");
            if (result != null)
                Categories = result;
        }

        public async Task<SuperCourse> GetSingleCourse(int id)
        {
            var result = await _http.GetFromJsonAsync<SuperCourse>($"api/supercourse/{id}");
            if (result != null)
                return result;

            throw new Exception("Course not found");
        }

        public async Task GetSuperCourses()
        {
            var result = await _http.GetFromJsonAsync<List<SuperCourse>>("api/supercourse");
            if (result != null)
                Courses = result;
            
        }

        public async Task UpdateSuperCourse(SuperCourse course)
        {
            var result = await _http.PutAsJsonAsync($"api/supercourse({course.Id}", course);
            await SetCourse(result);
        }

      
    }
}
