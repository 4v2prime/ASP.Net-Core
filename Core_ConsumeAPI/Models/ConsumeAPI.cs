
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_ConsumeAPI.Models
{
    public class ConsumeAPI
    {
        //country url and key
        private const string countryapi = "https://api.countrystatecity.in/v1/countries";
        private const string countryAPiKey = "NHhvOEcyWk50N2Vna3VFTE00bFp3MjFKR0ZEOUhkZlg4RTk1MlJlaA==";
        Student Student = new Student();
        public List<Student> StudList()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7128/");
                var response = client.GetAsync("api/student");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<List<Student>>();
                    readTask.Wait();
                    return Student.ListStudent = readTask.Result; ;
                }
            }
            return new List<Student>();
        }
        /// <summary>
        /// this method is for saving the student details
        /// </summary>
        /// <returns></returns>
        public bool SaveStudent(Student save)
        {

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7128/");
            var postTask = client.PostAsJsonAsync<Student>("api/student", save);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public bool UpdateStudent(Student stud)
        {
            using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7128/") };
            var putTask = client.PutAsJsonAsync<Student>($"api/student/{stud.Id}", stud);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// this method is for updating the student details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteStudent(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7128/");
                var deleteTask = client.DeleteAsync("api/student/" + id);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// getting the details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>object of student</returns>
        public async Task<Student> GetByIdAsync(int id)
        {
            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7128/") };

                var response = await client.GetAsync($"api/student/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Student>() ?? new Student();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching student: {ex.Message}");
            }
            return new Student();
        }
        public List<SelectListItem> ListCountry()
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("X-CSCAPI-KEY", countryAPiKey);
                var response = client.GetAsync(countryapi);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var countryListTask = result.Content.ReadFromJsonAsync<List<Country>>();
                    countryListTask.Wait();
                    var countryList = countryListTask.Result;
                    return countryList?.Select(c => new SelectListItem
                    {
                        Value = c.Iso2,
                        Text = c.Name
                    }).ToList() ?? new List<SelectListItem>();
                }
            }
            catch
            {
                //handle the exception
            }
            return new List<SelectListItem>();
        }
        public List<SelectListItem> ListState(string countryIso2)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("X-CSCAPI-KEY", countryAPiKey);
                var response = client.GetAsync($"{countryapi}/{countryIso2}/states");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var stateListTask = result.Content.ReadFromJsonAsync<List<State>>();
                    stateListTask.Wait();
                    var stateList = stateListTask.Result;
                    return stateList?.Select(s => new SelectListItem
                    {
                        Value = s.Iso2,
                        Text = s.Name
                    }).ToList() ?? new List<SelectListItem>();
                }
            }
            catch
            {
                //handle the exception
            }
            return new List<SelectListItem>();
        }
        public async Task<List<SelectListItem>> ListCityAsync(string countryIso2, string stateIso2)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("X-CSCAPI-KEY", countryAPiKey);

                string apiUrl = $"{countryapi}/{countryIso2}/states/{stateIso2}/cities";
                var response = await client.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                    return new List<SelectListItem>(); // Return empty list on failure

                var cityList = await response.Content.ReadFromJsonAsync<List<City>>();

                return cityList?.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(), // Ensure Id is a valid property
                    Text = c.Name
                }).ToList() ?? new List<SelectListItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching cities: {ex.Message}");
                return new List<SelectListItem>(); // Return empty list on exception
            }
        }

    }
}
