using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPostService.Services;
using System.Windows.Input;
using AppPostService.Models;

namespace AppPostService.ViewModels
{
    public partial class TodosViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Todos> todos;

        public ICommand getTodosCommand { get; set; }

        public TodosViewModel()
        {
            getTodosCommand = new Command(getTodos);
        }

        public async void getTodos()
        {
            TodosService todosService = new TodosService();
            Todos = await todosService.getTodos();
        }
    }
}

