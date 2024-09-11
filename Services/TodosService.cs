using AppPostService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppPostService.Services
{
    public class TodosService

    {
        private HttpClient httpClient;
        private Todos todos;
        private List<Todos> todo;
        private JsonSerializerOptions jsonSerializerOptions;

        public TodosService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ObservableCollection<Todos>> getTodos()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/todos");
            ObservableCollection<Todos> userTodos = new ObservableCollection<Todos>();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    userTodos = JsonSerializer.Deserialize<ObservableCollection<Todos>>(content, jsonSerializerOptions);
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return userTodos;
        }
    }
}